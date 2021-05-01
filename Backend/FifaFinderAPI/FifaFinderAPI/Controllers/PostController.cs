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
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PostController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var allPosts = dbContext.Posts;

            return new JsonResult(allPosts);
        }

        [HttpPost]
        public JsonResult Post(Post post)
        {
            var postToInsert = new Post(post.Type, post.Platform, post.Position, post.PlayerRating, post.Description);
            dbContext.Posts.Add(postToInsert);
            dbContext.SaveChanges();

            return new JsonResult("Post Created!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var postToDelete = dbContext.Posts.FirstOrDefault(p => p.ID == id);
            dbContext.Posts.Remove(postToDelete);
            dbContext.SaveChanges();

            return new JsonResult("Deleted Successfully!");
        }

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

            return new JsonResult("Updated Successfully!");
        }

    }
}
