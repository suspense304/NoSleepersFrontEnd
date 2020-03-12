using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoSleepers.Data
{
    public interface IStoryRepo
    {
        List<Story> GetAll();
        Story GetById(int storyId);
        List<Story> GetNewest(int count);
        Story GetByUserId(int authorId);
        Author GetAuthorByStoryId(int storyId);
        Task WriteRatingForStory(int storyId, int userId, int score);
        Task SetFavorite(int storyId, int userId);
    }
}
