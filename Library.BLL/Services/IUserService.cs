using Library.BLL.Dto;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Services
{
    public interface IUserService
    {
        IEnumerable<UserInfo> GetAll(int offset, int limit);

        UserInfo GetById(Guid id);

        AuthenticateResponse Register(UserInfo user, ref string errorMessage);

        bool Update(UserInfo user);

        bool? Delete(Guid id);
        UserInfo GetByLoginAndPassword(string username, string password);

        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
