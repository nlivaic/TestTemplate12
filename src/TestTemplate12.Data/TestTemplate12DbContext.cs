using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplate12.Core.Entities;

namespace TestTemplate12.Data
{
    public class TestTemplate12DbContext : DbContext
    {
        public TestTemplate12DbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
