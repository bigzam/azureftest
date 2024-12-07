using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionNet8Test
{
    public class EventHubTest
    {
        private readonly ILogger<EventHubTest> _logger;

        public EventHubTest(ILogger<EventHubTest> logger)
        {
            _logger = logger;
        }

        [Function("ListenExpiredClaimEvents")]
        public async Task ListenExpiredClaimEvents(
            [QueueTrigger("%ExpiredClaimEventQueueName%", Connection = "ExpiredClaimEventQueueConnection")] string expiredClaimMsg)
        {
            try
            {
                this._logger.LogInformation(expiredClaimMsg);
                await Task.Yield();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

            }
        }
    }
}
