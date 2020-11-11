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
    public class RecoverController : ControllerBase
    {
        private readonly LoginContext _context;

        public RecoverController(LoginContext context)
        {
            _context = context;
        }

        // GET: api/Recover/{credentials}
        // This method will check for the user with given email and confirm if the password matches
        [HttpGet("{cred}")]
        public async Task<ActionResult<User>> CheckUser(string cred)
        {
            // Splits credentials
            var creds = cred.Split("|||");
            var email = creds[0];
            var name = creds[1];
            var number = Convert.ToInt32(creds[2]);

            // Set "score"
            int score = 0;

            // Create a list with all users
            var users = await _context.Users.ToListAsync();

            // Check the list for the email
            foreach (User user in users)
            {
                // Check if credentials match
                if (user.Email == email)
                {
                    if (user.Name == name)
                    {
                        score += 1;
                    }

                    if (user.LuckyNumber == number)
                    {
                        score += 1;
                    }

                    // Do stuff accordingly to score
                    // IMPORTANT: this part is "this code exclusive"
                    if (score == 2)
                    {
                        var user2 = await _context.Users.FindAsync(user.UserId);
                        user2.Password = "NewPassword";
                        _context.Entry(user2).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        return user;
                    }
                }
            }

            return NotFound();
        }
    }
}
