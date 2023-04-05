using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Services
{
    public interface IEditionService
    {
        bool Create(Edition edition);

        bool Update(Edition edition);

        bool? Delete(Guid id);

        Edition GetById(Guid id);

        List<Edition> GetAll(int offset, int limit);
    }
}
