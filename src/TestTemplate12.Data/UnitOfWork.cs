using System.Threading.Tasks;
using TestTemplate12.Common.Interfaces;

namespace TestTemplate12.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTemplate12DbContext _dbContext;

        public UnitOfWork(TestTemplate12DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}