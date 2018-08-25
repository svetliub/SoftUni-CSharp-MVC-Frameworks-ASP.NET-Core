namespace MagicOfSewing.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public User()
        {
            this.Articles = new List<Article>();
            this.Videos = new List<Video>();
            this.Posts = new List<Post>();
        }
        
        public string AvatarUrl { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Video> Videos { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
