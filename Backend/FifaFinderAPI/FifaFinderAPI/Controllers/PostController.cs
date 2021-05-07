using FifaFinderAPI.Library.Binding;
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
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PostController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        // GET Request which returns the entire Post table
        [HttpGet]
        public JsonResult Get()
        {
            var allPosts = dbContext.Posts;
            if (allPosts != null)
            {
                return new JsonResult(allPosts);
            }
            return new JsonResult("Table not found");

        }

        // POST Request which adds a record to the Post table on success, returning feedback of success 
        [HttpPost("{userID}")]
        public JsonResult Post(AddPostBindingModel bindingModel, int userID)
        {
            bindingModel.UserID = userID;
            var postToInsert = new Post() {
                Type = bindingModel.Type,
                Platform = bindingModel.Platform,
                Position = bindingModel.Position,
                User = dbContext.Users.FirstOrDefault(u => u.ID == userID),
                PlayerRating = bindingModel.PlayerRating,
                Description = bindingModel.Description,
                CreatedAt = DateTime.Now
            };
           
            dbContext.Posts.Add(postToInsert);
            dbContext.SaveChanges();

            return new JsonResult("Post Created!");
        }

        // DELETE Request which deletes rthe record specified from the id parameter
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var postToDelete = dbContext.Posts.FirstOrDefault(p => p.ID == id);
            dbContext.Posts.Remove(postToDelete);
            dbContext.SaveChanges();

            return new JsonResult("Post Deleted!");
        }

        // PUT Request which edits an existing record with the passed in new details, returns feedback of success
        [HttpPut]
        public JsonResult Put(Post post)
        {
            var postToUpdate = dbContext.Posts.FirstOrDefault(p => p.ID == post.ID);
            postToUpdate.Type = post.Type;
            postToUpdate.Platform = post.Platform;
            postToUpdate.Position = post.Position;
            postToUpdate.PlayerRating = post.PlayerRating;
            postToUpdate.Description = post.Description;
            dbContext.SaveChanges();

            return new JsonResult("Post Updated!");
        }

    }
}
