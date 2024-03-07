using System;
using System.Text;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TFDataProcessingApp.Service;

namespace TFDataProcessingApp
{
    public class TFDataProcessor
    {
        private readonly ILogger<TFDataProcessor> logger;

        public TFDataProcessor(ILogger<TFDataProcessor> logger)
        {
            this.logger = logger;
        }

        [Function(nameof(TFDataProcessor))]
        public async Task Run([EventHubTrigger("c2s-eh-sandip", Connection = "TFDataEventHubConnection")] EventData[] events)
        {
            await new DataService(this.logger).ProcessEventsAsync(events);
            //foreach (EventData @event in events)
            //{
            //    _logger.LogInformation("Event Body: {body}", Encoding.UTF8.GetString(@event.EventBody.ToArray()));
            //    _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
            //}
        }
    }
}
