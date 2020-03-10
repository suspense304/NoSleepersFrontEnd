using System;

namespace NoSleepers.Core
{
    public class Story
    {
        public int StoryID { get; set; }
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public string Url { get; set; }

        public Author Author { get; set; }
    }
}
