using TestTemplate12.Core.Entities;
using TestTemplate12.Core.Interfaces;

namespace TestTemplate12.Data.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(TestTemplate12DbContext context)
            : base(context)
        {
        }
    }
}
