using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Library.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<AuthorService> logger;
        public AuthorService(ApplicationContext context, ILogger<AuthorService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Create(Author author)
        {
            try
            {
                using (context)
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }

        public bool Update(Author author)
        {
            try
            {
                using (context)
                {
                    context.Authors.Update(author);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }

        public bool? Delete(Guid id)
        {
            try
            {
                using (context)
                {
                    Author author = context.Authors.Find(id);
                    if (author is null)
                    {
                        return null;
                    }
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }

        public List<Author> GetAuthors(int offset, int limit)
        {
            return context.Authors.Skip(offset).Take(limit).ToList();
        }

        public Author GetById(Guid id)
        {
            return context.Authors.Find(id);
        }
    }
}
