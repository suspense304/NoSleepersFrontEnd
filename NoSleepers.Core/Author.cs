using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Core
{
    public class Author
    {
        public Author()
        {
            Stories = new List<Story>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Verified { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
