using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifaFinderAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PictureURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual List<Post> Posts { get; set; }

        public User() { }
        public User(string usn, string pswd, string ema, string url)
        {
            Username = usn;
            Password = pswd;
            Email = ema;
            PictureURL = url;
            CreatedAt = DateTime.Now;
        }
    }
}
