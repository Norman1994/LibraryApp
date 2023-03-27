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

        bool Create(UserInfo user);

        bool Update(UserInfo user);

        bool? Delete(Guid id);
        UserInfo GetByLoginAndPassword(string username, string password);
    }
}
