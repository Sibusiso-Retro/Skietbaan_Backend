using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Skietbaan_T2.Models;
using Backend_Skietbaan_T2.RequestModels;
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

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // POST: api/Login
        [HttpPost]
        public ActionResult<string> VerifyUser([FromBody] RequestUser Person)
        {
            List<User> users = _context.Users.ToList<User>();
            for(int i = 0; i < users.Count; i++)
            {
                if(users.ElementAt(i).Username.Equals(Person.Username) && users.ElementAt(i).Password.Equals(Person.Password))
                {
                    return "access granted";
                }
            }
            return "incorrect login details";
        }
    }
}
