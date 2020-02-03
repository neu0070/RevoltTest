using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using RestSharp;
using RevoltTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RevoltTest.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext AppContext)
        {
            _context = AppContext;
        }

        public async Task<List<ApplicationUser>> GetAllUser()
        {
            return await _context.Set<ApplicationUser>().ToListAsync();
        }

        public async Task<string> GetApplicationUserID(string id1, string id2)
        {
            var user = await _context.Set<ApplicationUser>().Where(x => x.ID1 == id1).Where(s => s.ID2 == id2).FirstOrDefaultAsync();
            return user.Id;
        }

        public List<string> GetEnglishWord()
        {
            var client = new RestClient("https://random-word-api.herokuapp.com/");

            var requestKey = new RestRequest("key?", Method.GET);
            var responseKey = client.Execute(requestKey);

            var request = new RestRequest($"word?key={responseKey.Content}&number=2", Method.GET);
            var response = client.Execute(request);

            var objects = JsonConvert.DeserializeObject<List<string>>(response.Content);

            return objects;
        }

        public async Task SendEmail(string to, string text)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(to));
            message.From.Add(new MailboxAddress("postmaster@mandao.cz"));

            message.Subject = "message subject";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = text
            };

            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                emailClient.Connect("smtp.forpsi.com", 465, MailKit.Security.SecureSocketOptions.Auto);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate("postmaster@mandao.cz", "Fordmustang2018");

                await emailClient.SendAsync(message);

                emailClient.Disconnect(true);
            }
        }

        public async Task UpdateUserIDs()
        {
            var users = await GetAllUser();

            foreach (var user in users)
            {
                var words = GetEnglishWord();
                user.ID1 = words[0];
                user.ID2 = words[1];

                await _context.SaveChangesAsync();
            }
        }
    }
}
