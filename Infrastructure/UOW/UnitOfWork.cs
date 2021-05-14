using MCIT_Task.Infrastructure.DBContext;
using MCIT_Task.Infrastructure.Repostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Complete()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public GenericRepository<TEntity> GetRepo<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_dbContext);
        }
    }
}
