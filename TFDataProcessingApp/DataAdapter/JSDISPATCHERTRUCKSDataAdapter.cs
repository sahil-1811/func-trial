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
    internal class JSDISPATCHERTRUCKSDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingJsdispatchertruck = JsonSerializer.Deserialize<Jsdispatchertruck>(rawDataEntity, options)!;
            incomingJsdispatchertruck.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Jsdispatchertrucks
                    .Any(a => a.Recid == incomingJsdispatchertruck.Recid && a.Dataareaid == incomingJsdispatchertruck.Dataareaid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Jsdispatchertruck.Attach(incomingJsdispatchertruck);
                //    dbContext.Jsdispatchertruck.Remove(incomingJsdispatchertruck);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Jsdispatchertrucks.Add(incomingJsdispatchertruck);
                    }
                    else
                    {
                        dbContext.Update(incomingJsdispatchertruck);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
