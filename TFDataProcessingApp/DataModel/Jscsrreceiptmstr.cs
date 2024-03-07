using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TFDataProcessingApp.DataModel;

public partial class Jscsrreceiptmstr
{
    public string Receiptno { get; set; } = null!;

    public int Status { get; set; }

    public string Voucher { get; set; } = null!;

    public string Accountnum { get; set; } = null!;

    public string Contract { get; set; } = null!;

    public string Itemgroupid { get; set; } = null!;

    public string Locationid { get; set; } = null!;

    public string Purchmethod { get; set; } = null!;

    public DateTime Effective { get; set; }

    public string Hauler { get; set; } = null!;

    public string Truck { get; set; } = null!;

    public string Driver { get; set; } = null!;

    public string Trailer1 { get; set; } = null!;

    public string Trailer2 { get; set; } = null!;

    public string Fieldidtag { get; set; } = null!;

    public string Billoflading { get; set; } = null!;

    public string Journalid { get; set; } = null!;

    public decimal Settlevalue { get; set; }

    public int Freightstatus { get; set; }

    public string Freightvoucher { get; set; } = null!;

    public decimal Freightpaid { get; set; }

    public string Region { get; set; } = null!;

    public string Season { get; set; } = null!;

    [JsonPropertyName("DEL_SOURCE")]
    public string DelSource { get; set; } = null!;

    [JsonPropertyName("DEL_ADVANCEPERCENT")]
    public decimal DelAdvancepercent { get; set; }

    public string Jscsrinvjournalnum { get; set; } = null!;

    public string Jsinvsettlementjournum { get; set; } = null!;

    public string Scaleticketid { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public int Receipttype { get; set; }

    public string Origreceipt { get; set; } = null!;

    public string Harvesterinvoice { get; set; } = null!;

    public int Corrected { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Modifiedtime { get; set; }

    public string Modifiedby { get; set; } = null!;

    public long Modifiedtransactionid { get; set; }

    public DateTime Createddate { get; set; }

    public int Createdtime { get; set; }

    public string Createdby { get; set; } = null!;

    public long Createdtransactionid { get; set; }

    public string Dataareaid { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }

    public string Rejectreceiptno { get; set; } = null!;

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
