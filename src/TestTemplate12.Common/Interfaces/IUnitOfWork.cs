using System.Threading.Tasks;

namespace TestTemplate12.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}