using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Data
{
    public interface IAuthorRepo
    {
        public List<Author> GetAll();
        public Author GetById(int authorId);

    }
}
