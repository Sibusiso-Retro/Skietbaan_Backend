using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Skietbaan_T2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Skietbaan_T2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ModelsContext _context;
        public LoginController(ModelsContext db)
        {
            _context = db;
        }
        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<string>> VerifyUser([FromBody] User user)
        {
            if (user == null || user.Username == null || user.Password == null) BadRequest();

            List<User> users = _context.Users.ToList<User>();
            for(int i = 0; i < users.Count; i++)
            {
                if(users.ElementAt(i).Username.Equals(user.Username) && users.ElementAt(i).Password.Equals(user.Password))
                {
                    return "access granted";
                }
            }
            return "incorrect login details";
        }
    }
}
