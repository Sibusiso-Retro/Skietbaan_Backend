
using Backend_Skietbaan_T2.Controllers;
using Backend_Skietbaan_T2.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace Backend_Skietbaan_T2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private ModelsContext _context;
        public UserController(ModelsContext db)
        {
            _context = db;
        }

        // GET: api/User
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<User>>> Get()
        {
            List<User> users =  _context.Users.ToList<User>();
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user =  _context.Users.Find(id);
            if(user == null)
            {
                List<User> users = _context.Users.ToList();
                for(int i = 0; i < users.Count; i++)
                {
                    if(users.ElementAt(i).Id == id)
                    {
                        return users.ElementAt(i);
                    }
                }
            }
            return user;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {

            if (user == null)
            {
                return BadRequest("Invalid user Id");
            }
            else if (user.Id <= 0)
            {
                return BadRequest("Invalid user Id");
            }
            else
            {
                List<User> users = _context.Users.ToList();
                for(int i = 0; i < users.Count; i++)
                {
                    User tmpUser = users.ElementAt(i);
                    if(tmpUser.Username.Equals(user.Username) && tmpUser.Surname.Equals(user.Surname))
                    {
                        return BadRequest("User already exist");
                    }
                }
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
