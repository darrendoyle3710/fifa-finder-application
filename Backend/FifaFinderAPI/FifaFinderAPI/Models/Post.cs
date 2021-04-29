using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaFinderAPI.Models
{
    public class Post
    {
        public int ID { get; set; }
        public PostType PostType { get; set; }
        public Platform Platform { get; set; }
        public Position Position { get; set; }
        public PlayerRating PlayerRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }

        public Post() { }
        public Post(PostType pt, Platform pl, Position pos, PlayerRating prtg, string desc)
        {
            PostType = pt;
            Platform = pl;
            Position = pos;
            PlayerRating = prtg;
            Description = desc;
            CreatedAt = DateTime.Now;
        }
    }
}
