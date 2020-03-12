using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Core
{
    public class Rating
    {
        public int UserId { get; set; }
        public int StoryId { get; set; }
        public double Score { get; set; }

    }
}
