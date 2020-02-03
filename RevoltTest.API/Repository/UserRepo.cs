using Microsoft.EntityFrameworkCore;
using RevoltTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RevoltTest.API.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext AppContext)
        {
            _context = AppContext;
        }

        public string GetEnglishWord()
        {
            var client = new WebClient();
            var downloadedString = client.DownloadString("http://randomword.setgetgo.com/get.php");
            return downloadedString;
        }

        public async Task UpdateUserIDs()
        {
            var users = await _context.Set<ApplicationUser>().ToListAsync();

            foreach(var user in users)
            {
                user.ID1 = GetEnglishWord();
                user.ID2 = GetEnglishWord();

                await _context.SaveChangesAsync();
            }
        }
    }
}
