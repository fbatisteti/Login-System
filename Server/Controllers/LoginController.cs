using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginContext _context;

        public LoginController(LoginContext context)
        {
            _context = context;
        }

        // GET: api/Login/{
        // This method will check for the user with given email and confirm if the password matches
        [HttpGet("{cred}")]
        public async Task<ActionResult<User>> GetUser(string cred)
        {
            // Splits credentials
            var creds = cred.Split("|||");
            var email = creds[0];
            var password = creds[1];

            // Create a list with all users
            var users = await _context.Users.ToListAsync();

            // Check the list for the email
            foreach (User user in users)
            {
                // Check if email and password match
                if (user.Email == email)
                {
                    if (user.Password == password)
                    {
                        return user;
                    }
                }
            }

            return NotFound();
        }
    }
}
