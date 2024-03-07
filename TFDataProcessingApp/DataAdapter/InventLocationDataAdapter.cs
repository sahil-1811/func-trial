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
    internal class InventLocationDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingInventlocation = JsonSerializer.Deserialize<Inventlocation>(rawDataEntity, options)!;
            incomingInventlocation.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Inventlocations.Any(a => a.Inventlocationid == incomingInventlocation.Inventlocationid && a.Dataareaid == incomingInventlocation.Dataareaid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Inventlocations.Attach(incomingInventlocation);
                //    dbContext.Inventlocations.Remove(incomingInventlocation);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Inventlocations.Add(incomingInventlocation);
                    }
                    else
                    {
                        //TODO: Set SyncServiceLastModifiedDateUTC
                        dbContext.Update(incomingInventlocation);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
