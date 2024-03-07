using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TFDataProcessingApp.Config;
using TFDataProcessingApp.DataModel;
using TFDataProcessingApp.Model;

namespace TFDataProcessingApp.DataAdapter
{
    internal class AddressDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingAddress = JsonSerializer.Deserialize<Address>(rawDataEntity, options)!;
            incomingAddress.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Addresses.Any(a => a.Recid == incomingAddress.Recid && a.Dataareaid == incomingAddress.Dataareaid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Addresses.Attach(incomingAddress);
                //    dbContext.Addresses.Remove(incomingAddress);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Addresses.Add(incomingAddress);
                    }
                    else
                    {
                        //TODO: Set SyncServiceLastModifiedDateUTC
                        dbContext.Update(incomingAddress);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
