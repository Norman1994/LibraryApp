using System;
using System.Linq;
using Library.DAL;
using Library.DAL.Entities;
using Library.JWT;
using Library.BLL.Dto;
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
        public AuthenticateResponse Register(UserInfo user, ref string errorMessage)
        {
            try
            {
                if(CanRegister(user, ref errorMessage))
                {
                    using (context)
                    {
                        user.Id = Guid.NewGuid();
                        context.Users.Add(user);
                        context.SaveChanges();
                    }

                    return Authenticate(new AuthenticateRequest { UserName = user.Username, Password = user.Password });
                }
                return null;
                
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            UserInfo user = context.Users.FirstOrDefault(x => x.Username.Equals(model.UserName) && x.Password.Equals(model.Password));

            if (user is null)
            {
                return null;
            }
            string token = JWTTokenCreator.GetJWT(user);

            return new AuthenticateResponse(user, token);
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

        private bool CanRegister(UserInfo user, ref string errorMessage)
        {
            if(!(context.Users.FirstOrDefault(x => x.Username.Equals(user.Username)) is null))
            {
                errorMessage = "Пользователь с таким именем уже существует";
                return false;
            }
            else if(!(context.Users.FirstOrDefault(x => x.Email.Equals(user.Email)) is null))
            {
                errorMessage = "Почтовый адрес уже зарегистрирован";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
