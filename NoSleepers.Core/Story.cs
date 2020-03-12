using System;
using System.Collections.Generic;
using System.Linq;

namespace NoSleepers.Core
{
    public class Story
    {
        public Story()
        {
            Ratings = new List<Rating>();
            Favorites = new List<Favorite>();
        }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public double AverageRating { get; private set; }
        public int NumberOfRatings => Ratings.Count;
        public string Title { get; set; }
        public string Url { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public void WriteRating(int userId, double newRating)
        {
            if (HasUserWrittenRating(userId))
            {
                Ratings.FirstOrDefault(c => c.UserId == userId && c.StoryId == this.Id).Score = newRating;
                AverageRating = Ratings.Average(r => r.Score);
            }
            else
            {
                Ratings.Add(new Rating() { StoryId = this.Id, Score = newRating, UserId = userId });
                AverageRating = ((AverageRating * NumberOfRatings - 1) + newRating) / NumberOfRatings;
            }
        }

        private bool HasUserWrittenRating(int userId)
        {
            return Ratings.Any(rat => rat.UserId == userId);
        }

        public void SetFavoritie(int userId)
        {
            Favorite newFavorite = Favorites.FirstOrDefault(w => w.UserId == userId);
            if (newFavorite != null)
            {
                Favorites.Remove(newFavorite);
            }
            else
            {
                Favorites.Add(newFavorite);
            }
        }

    }
    public class StoryRating
    {
        public int StoryId { get; set; }
        public int NumberOfRatings { get; set; }
        public double Rating { get; set; }
    }

    
}
