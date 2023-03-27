using System;
using System.Linq;
using Library.DAL;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Library.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<UserService> logger;
        public UserService(ApplicationContext context, ILogger<UserService> logger)
        {
            this.logger = logger;
            this.context = context;
        }
        public bool Create(UserInfo user)
        {
            try
            {
                using (context)
                {
                    user.Id = Guid.NewGuid();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return false;
            }
        }

        public bool Update(UserInfo user)
        {
            try
            {
                using (context)
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return false;
            }
        }

        public bool? Delete(Guid id)
        {
            try
            {
                using (context)
                {
                    UserInfo user = context.Users.Find(id);
                    
                    if(user is null)
                    {
                        return null;
                    }
                    context.Users.Remove(user);
                    return true;
                }
                    
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return false;
            }
        }

        public IEnumerable<UserInfo> GetAll(int offset, int limit)
        {
            return context.Users.Skip(offset).Take(limit);
        }

        public UserInfo GetById(Guid id)
        {
            using (context)
            {
                return context.Users.Find(id);
            }    
        }

        public UserInfo GetByLoginAndPassword(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }
    }
}
