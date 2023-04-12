using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Library.BLL.Dto;
using AutoMapper;

namespace Library.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<AuthorService> logger;
        private readonly IMapper mapper;
        public AuthorService(ApplicationContext context, ILogger<AuthorService> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public bool Create(AuthorDto authorDto)
        {
            try
            {
                using (context)
                {
                    Author newAuthor = mapper.Map<Author>(authorDto);

                    context.Authors.Add(newAuthor);
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

        public bool Update(AuthorDto authorDto)
        {
            try
            {
                using (context)
                {
                    Author newAuthor = context.Authors.Where(x => x.Id == authorDto.Id).FirstOrDefault();
                    newAuthor = mapper.Map<Author>(authorDto);

                    context.Authors.Update(newAuthor);
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
            return context.Authors.Include(x => x.Books).Skip(offset).Take(limit).ToList();
        }

        public Author GetById(Guid id)
        {
            return context.Authors.Find(id);
        }
    }
}
