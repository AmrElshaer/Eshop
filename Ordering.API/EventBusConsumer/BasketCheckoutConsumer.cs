using EventBus.Messages.Events;
using MassTransit;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(ILogger<BasketCheckoutConsumer> logger)
        {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {

            _logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", context.Message.FirstName );
            await Task.FromResult(()=>2);

        }
    }
}
