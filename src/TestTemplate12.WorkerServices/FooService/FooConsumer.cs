using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using TestTemplate12.Core.Events;

namespace TestTemplate12.WorkerServices.FooService
{
    public class FooConsumer(ILogger<FooConsumer> Logger) : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context)
        {
            Logger.LogInformation("Talking from FooConsumer.");
            return Task.CompletedTask;
        }
    }
}
