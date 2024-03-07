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
    internal class InventdimDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingInventdim = JsonSerializer.Deserialize<Inventdim>(rawDataEntity, options)!;
            incomingInventdim.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Inventdims.Any(a => a.Dataareaid == incomingInventdim.Dataareaid && a.Inventdimid == incomingInventdim.Inventdimid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Inventdims.Attach(incomingInventdim);
                //    dbContext.Inventdims.Remove(incomingInventdim);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Inventdims.Add(incomingInventdim);
                    }
                    else
                    {
                        //TODO: Set SyncServiceLastModifiedDateUTC
                        dbContext.Update(incomingInventdim);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
