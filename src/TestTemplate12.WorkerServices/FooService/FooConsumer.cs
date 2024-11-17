using System.Threading.Tasks;
using MassTransit;
using TestTemplate12.Core.Events;

namespace TestTemplate12.WorkerServices.FooService
{
    public class FooConsumer : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context) =>
            Task.CompletedTask;
    }
}
