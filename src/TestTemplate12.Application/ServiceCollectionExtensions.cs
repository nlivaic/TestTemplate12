using Microsoft.Extensions.DependencyInjection;
using TestTemplate12.Application.Pipelines;

namespace TestTemplate12.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestTemplate12ApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
            services.AddPipelines();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
