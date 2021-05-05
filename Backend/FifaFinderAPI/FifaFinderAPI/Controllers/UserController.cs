using FifaFinderAPI.Data;
using FifaFinderAPI.Models;
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

        [HttpGet]
        public JsonResult Get()
        {
            var allUsers = dbContext.Users;

            return new JsonResult(allUsers);
        }

        [HttpPost]
        [Route("register")]
        public JsonResult RegisterUser(User user)
        {
            var queryEmailRegistered = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            var queryUsernameRegistered = dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
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

            var userToInsert = new User(user.Username, user.Password, user.Email, user.PictureURL);
            dbContext.Users.Add(userToInsert);
            dbContext.SaveChanges();

            return new JsonResult("User Registered!");

        }

        [HttpPost]
        [Route("login")]
        public JsonResult LoginUser(User user)
        {
            var queryLoginAttempt = dbContext.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (queryLoginAttempt != null) {
                return new JsonResult(dbContext.Users.FirstOrDefault(u => u.Username == user.Username));
            } else return new JsonResult("Incorrect username or password" + user.Username);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.ID == id);
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();

            return new JsonResult("User Deleted!");
        }

       // maybe add edit

    }
}
