using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Core
{
    public class User
    {
        public string Username { get; set; }
        public string RedditUser { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }      
        public List<Story> FavoriteStories { get; set; }
        public List<Author> FavoriteAuthors { get; set; }
        public bool Verified { get; set; }
        
        
    }
    public class Writer : User
    {
        public List<Story> Stories { get; set; }
        // Future
        // public List<PublishedWorks> PublishedWorks {get;set;}
    }

    public class Reader : User
    {

    }
}
