using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevoltTest.Repository;

namespace RevoltTest.Services.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly IUserRepo _repoUser;

        public GenerateController(IUserRepo userRepo)
        {
            _repoUser = userRepo;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                await _repoUser.UpdateUserIDs();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}