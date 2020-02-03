using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevoltTest.Models;
using RevoltTest.Repository;

namespace RevoltTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepo _repoUser;
        private readonly IUserActivityRepo _repoUserActivity;

        public HomeController(ILogger<HomeController> logger, IUserRepo userRepo, IUserActivityRepo userActivityRepo)
        {
            _logger = logger;
            _repoUser = userRepo;
            _repoUserActivity = userActivityRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("newpage/{id1}/{id2}")]
        public async Task<IActionResult> newPage([FromRoute] string id1, [FromRoute] string id2)
        {
            string message = "success";
            try
            {
                var userID = await _repoUser.GetApplicationUserID(id1, id2);

                await _repoUserActivity.InsertUserActivity(new Data.UserActivity()
                {
                    DateOfExecution = DateTime.Now,
                    UserID = userID
                });
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            

            return View("newPage",message);
        }
    }
}
