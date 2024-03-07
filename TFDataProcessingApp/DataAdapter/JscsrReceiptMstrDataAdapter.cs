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
    internal class JscsrReceiptMstrDataAdapter
    {
        public void SaveData(string rawDataEntity)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var baseEntity = JsonSerializer.Deserialize<BaseEntity>(rawDataEntity, options);
            var incomingJscsrreceiptmstr = JsonSerializer.Deserialize<Jscsrreceiptmstr>(rawDataEntity, options)!;
            incomingJscsrreceiptmstr.SyncServiceLastModifiedDateUtc = DateTime.UtcNow;
            using (var dbContext = new ProdRDBContext(new TFDataProcessingConfiguration()))
            {
                var isRowExists = dbContext.Jscsrreceiptmstrs
                    .Any(a => a.Receiptno == incomingJscsrreceiptmstr.Receiptno && a.Dataareaid == incomingJscsrreceiptmstr.Dataareaid);

                //if (baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    dbContext.Jscsrreceiptmstrs.Attach(incomingJscsrreceiptmstr);
                //    dbContext.Jscsrreceiptmstrs.Remove(incomingJscsrreceiptmstr);
                //}
                //else 
                if (!baseEntity.SYS_CHANGE_OPERATION.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!isRowExists)
                    {
                        dbContext.Jscsrreceiptmstrs.Add(incomingJscsrreceiptmstr);
                    }
                    else
                    {
                        dbContext.Update(incomingJscsrreceiptmstr);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
