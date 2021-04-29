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
            var postToInsert = new Post(post.PostType, post.Platform, post.Position, post.PlayerRating, post.Description);
            dbContext.Posts.Add(postToInsert);
            dbContext.SaveChanges();
            return new JsonResult("Post Created!");
        }
    }
}
