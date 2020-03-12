using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoSleepers.Data
{
    public class AuthorRepository : IAuthorRepo
    {
        private readonly NoSleepersDbContext _dbContext;

        public AuthorRepository(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int authorId)
        {
            return _dbContext.Authors.FirstOrDefault(a => a.Id == authorId);
        }
    }
}
