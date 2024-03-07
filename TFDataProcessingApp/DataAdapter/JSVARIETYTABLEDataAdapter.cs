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
    internal class JSVARIETYTABLEDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingJsvarietytable = JsonSerializer.Deserialize<Jsvarietytable>(rawDataEntity, options)!;
            incomingJsvarietytable.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Jsvarietytables.Any(a => a.Variety == incomingJsvarietytable.Variety);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Jsvarietytable.Attach(incomingAddress);
                //    dbContext.Jsvarietytable.Remove(incomingAddress);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Jsvarietytables.Add(incomingJsvarietytable);
                    }
                    else
                    {
                        dbContext.Update(incomingJsvarietytable);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
