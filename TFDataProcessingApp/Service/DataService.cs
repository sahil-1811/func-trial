using Azure.Messaging.EventHubs;
using Microsoft.Azure.Amqp;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TFDataProcessingApp.Config;
using TFDataProcessingApp.DataAdapter;
using TFDataProcessingApp.DataModel;
using TFDataProcessingApp.Model;

namespace TFDataProcessingApp.Service
{
    public class DataService
    {
        private readonly ILogger<TFDataProcessor> logger;

        public DataService(ILogger<TFDataProcessor> logger)
        {
            this.logger = logger;
        }

        public async Task ProcessEventsAsync(EventData[] events)
        {
            foreach (EventData eventData in events)
            {
                // Fetch Header Info
                var correlationId = eventData.CorrelationId;
                try
                {
                    string rawDataEntity = Encoding.UTF8.GetString(eventData.EventBody.ToArray());
                    this.logger.LogInformation($"RawEventData: {rawDataEntity}");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);

                    if (baseEntity == null)
                    {
                        this.logger.LogWarning("Not supported Data entity");
                        return;
                    }

                    switch (baseEntity.TABLE_NAME.ToUpper())
                    {
                        case "ADDRESS":
                            new AddressDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "INVENTDIM":
                            new InventdimDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "INVENTLOCATION":
                            new InventLocationDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "INVENTTRANS":
                            new InventTransDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "JSCSRRECEIPTMSTR":
                            new JscsrReceiptMstrDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "JSDISPATCHERTRUCKS":
                            new JSDISPATCHERTRUCKSDataAdapter().SaveData(rawDataEntity);
                            break;
                        case "JSVARIETYTABLE":
                            new JSVARIETYTABLEDataAdapter().SaveData(rawDataEntity);
                            break;
                    }

                }
                catch(Exception ex) 
                {
                    var message = ex.Message + "" + (ex.InnerException != null ? ex.InnerException.Message : "");
                    this.logger.LogError(ex, $"ProcessEventsAsync error! {message}");
                }
            }
        }
    }
}
