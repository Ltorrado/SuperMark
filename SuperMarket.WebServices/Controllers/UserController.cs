using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMark.Managers;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserManager Manager;


        public UserController(IUserRepository repository)
        {

            Manager = new UserManager(repository);
        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login(string user, string psw)
        {
            try
            {

                var result = await Manager.Login(user, psw);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
