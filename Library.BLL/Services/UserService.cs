using Library.DAL;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;
        public UserService(ApplicationContext context)
        {
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
    }
}
