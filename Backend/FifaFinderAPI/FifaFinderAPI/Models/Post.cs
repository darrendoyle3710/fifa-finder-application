using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaFinderAPI.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public string Position { get; set; }
        public int PlayerRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }

        public Post() { }
        public Post(string ty, string pl, string pos, int prtg, string desc)
        {
            Type = ty;
            Platform = pl;
            Position = pos;
            PlayerRating = prtg;
            Description = desc;
            CreatedAt = DateTime.Now;
        }
    }
}
