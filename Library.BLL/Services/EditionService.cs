using Library.DAL;
using Library.DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BLL.Services
{
    public class EditionService : IEditionService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<EditionService> logger;

        public EditionService(ApplicationContext context, ILogger<EditionService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Create(Edition edition)
        {
            try
            {
                using (context)
                {
                    context.Edtions.Add(edition);
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

        public bool? Delete(Guid id)
        {
            try
            {
                using (context)
                {
                    Edition edition = context.Edtions.Find(id);
                    if (edition is null)
                    {
                        return null;
                    }
                    context.Edtions.Remove(edition);
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

        public List<Edition> GetAll(int offset, int limit)
        {
            return context.Edtions.Skip(offset).Take(limit).ToList();
        }

        public Edition GetById(Guid id)
        {
            return context.Edtions.Find(id);
        }

        public bool Update(Edition edition)
        {
            try
            {
                context.Edtions.Update(edition);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }
    }
}
