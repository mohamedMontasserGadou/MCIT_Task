using MCIT_Task.Infrastructure.Repostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Infrastructure.UOW
{
    public interface IUnitOfWork
    {
        public GenericRepository<TEntity> GetRepo<TEntity>() where TEntity : class;
        public Task CompleteAsync();
    }
}
