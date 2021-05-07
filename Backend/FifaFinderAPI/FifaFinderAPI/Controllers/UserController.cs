using FifaFinderAPI.Library.Data;
using FifaFinderAPI.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaFinderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        // GET Request which returns the entire User table
        [HttpGet]
        public JsonResult GetUsers()
        {
            var allUsers = dbContext.Users;
            if(allUsers != null) return new JsonResult(allUsers);
            return new JsonResult("User table has no records");
        }

        // POST Request which verifies credentials are acceptable and adds them to the User table on success, returning the newly created record details
        [HttpPost]
        [Route("register")]
        public JsonResult RegisterUser(User user)
        {
            var queryEmailRegistered = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            var queryUsernameRegistered = dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            // verifiying if the user credentials already exist within the User table
            if (queryEmailRegistered != null && queryUsernameRegistered != null)
            {
                return new JsonResult("Username and Email already registered");
            } else if (queryUsernameRegistered != null)
            {
                return new JsonResult("Username already registered");
            } else if (queryEmailRegistered != null)
            {
                return new JsonResult("Email already registered");
            }

            // Inserting the new user
            var userToInsert = new User(user.Username, user.Password, user.Email);
            dbContext.Users.Add(userToInsert);
            dbContext.SaveChanges();

            // Returning the user that has been created
            return new JsonResult(dbContext.Users.FirstOrDefault(u => u.Username == user.Username));

        }

        // POST Request which attempts to log the user in returns the user record
        [HttpPost]
        [Route("login")]
        public JsonResult LoginUser(User user)
        {
            // checking for a matching username and password
            var queryLoginAttempt = dbContext.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            // the query will be null if the match hasnt been found. if conditional handles this accordingly
            if (queryLoginAttempt != null) {
                return new JsonResult(dbContext.Users.FirstOrDefault(u => u.Username == user.Username));
            } else return new JsonResult("Incorrect username or password");
        }

        // DELETE Request which deletes rthe record specified from the id parameter
        [HttpDelete("{id}")]
        public JsonResult DeleteUser(int id)
        {
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.ID == id);
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();

            return new JsonResult("User Deleted!");
        }

    }
}
