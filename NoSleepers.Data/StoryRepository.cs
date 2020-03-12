using Microsoft.EntityFrameworkCore;
using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSleepers.Data
{
    public class StoryRepository : IStoryRepo
    {
        private readonly NoSleepersDbContext _dbContext;

        public StoryRepository(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Author GetAuthorByStoryId(int storyId)
        {
            int authorId = _dbContext.Stories.Include(x => x.Author).FirstOrDefault(s => s.Id == storyId).AuthorId;
            return _dbContext.Authors.FirstOrDefault(a => a.Id == authorId);
        }
        public List<Story> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Story> GetNewest(int count)
        {
            return _dbContext.Stories.Include(x => x.Author).Take(count).OrderByDescending(x => x.Score).ToList();
        }

        public Story GetById(int storyId)
        {
            return _dbContext.Stories.Include(x => x.Author).FirstOrDefault(w => w.Id == storyId);
        }

        public Story GetByUserId(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task WriteRatingForStory(int storyId, int userId, int score)
        {
            // Get the story that was rated
            var story = await _dbContext.Stories.FirstOrDefaultAsync(story => story.Id == storyId);

            // Updating thestory with the new rating
            story.WriteRating(userId, score);

            //_dbContext.Stories.Update(story);

            // Save the updated story to the database
            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    _dbContext.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Story)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }

        }

        public async Task SetFavorite(int storyId, int userId)
        {
            var story = await _dbContext.Stories.FirstOrDefaultAsync(story => story.Id == storyId);

            story.SetFavoritie(userId);

            await _dbContext.SaveChangesAsync();
        }
    }
}
