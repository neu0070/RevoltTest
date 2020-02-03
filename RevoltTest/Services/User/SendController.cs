using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RevoltTest.Repository;

namespace RevoltTest.Services.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly IUserRepo _repoUser;
        private IWebHostEnvironment env;

        public SendController(IUserRepo userRepo, IWebHostEnvironment env)
        {
            _repoUser = userRepo;
            this.env = env;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repoUser.GetAllUser();

                foreach(var user in users)
                {
                    var message = GetEmailBody(user.ID1, user.ID2);

                    await _repoUser.SendEmail(user.Email, message);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public string GetEmailBody(string id1, string id2)
        {
            var pathToFile = env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "htmlpage.html";
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                var builder = new BodyBuilder();
                builder.HtmlBody = SourceReader.ReadToEnd();
                var port = HttpContext.Connection.LocalPort;
                var messageBody = string.Format(builder.HtmlBody, $"https://localhost:{port}/newpage/{id1}/{id2}");

                return messageBody;
            }
        }
    }
}