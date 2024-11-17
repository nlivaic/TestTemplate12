using System.Collections.Generic;
using TestTemplate12.Core.Entities;
using TestTemplate12.Data;

namespace TestTemplate12.Api.Tests.Helpers
{
    public static class Seeder
    {
        public static void Seed(this TestTemplate12DbContext ctx)
        {
            ctx.Foos.AddRange(
                new List<Foo>
                {
                    new ("Text 1"),
                    new ("Text 2"),
                    new ("Text 3")
                });
            ctx.SaveChanges();
        }
    }
}
