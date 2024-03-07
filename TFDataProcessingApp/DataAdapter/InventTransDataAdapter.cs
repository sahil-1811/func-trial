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
    internal class InventTransDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingInventtran = JsonSerializer.Deserialize<Inventtran>(rawDataEntity, options)!;
            incomingInventtran.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Inventtrans.Any(a =>
                a.Inventtransid == incomingInventtran.Inventtransid && a.Inventdimid == incomingInventtran.Inventdimid
                && a.Dataareaid == incomingInventtran.Dataareaid && a.Recid == incomingInventtran.Recid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Inventtrans.Attach(incomingInventtran);
                //    dbContext.Inventtrans.Remove(incomingInventtran);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Inventtrans.Add(incomingInventtran);
                    }
                    else
                    {
                        dbContext.Update(incomingInventtran);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
