using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TFDataProcessingApp.DataModel;

public partial class Inventlocation
{
    public string Inventlocationid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Manual { get; set; }

    public string Emptypalletlocation { get; set; } = null!;

    public decimal Maxpickingroutevolume { get; set; }

    public int Pickinglinetime { get; set; }

    public int Maxpickingroutetime { get; set; }

    public string Wmslocationiddefaultreceipt { get; set; } = null!;

    public string Wmslocationiddefaultissue { get; set; } = null!;

    public string Inventlocationidreqmain { get; set; } = null!;

    public int Reqrefill { get; set; }

    public int Inventlocationtype { get; set; }

    public string Inventlocationidquarantine { get; set; } = null!;

    public int Inventlocationlevel { get; set; }

    public string Reqcalendarid { get; set; } = null!;

    public int DelLeadtimetransfer { get; set; }

    public int DelCalendardaystransfer { get; set; }

    public int Wmsaislenameactive { get; set; }

    public int Wmsracknameactive { get; set; }

    public string Wmsrackformat { get; set; } = null!;

    public int Wmslevelnameactive { get; set; }

    public string Wmslevelformat { get; set; } = null!;

    public int Wmspositionnameactive { get; set; }

    public string Wmspositionformat { get; set; } = null!;

    public int Usewmsorders { get; set; }

    public string Inventlocationidtransit { get; set; } = null!;

    public string Vendaccount { get; set; } = null!;

    public string Jsproshipshipper { get; set; } = null!;

    public string Dataareaid { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }
        
    public string Jsdefaultcountingchanneld40001 { get; set; } = null!;

    [JsonPropertyName("JSDEFAULTCOUNTINGCHANNE2_40001")]
    public string Jsdefaultcountingchanne240001 { get; set; } = null!;

    [JsonPropertyName("JSDEFAULTCOUNTINGCHANNE3_40001")]
    public string Jsdefaultcountingchanne340001 { get; set; } = null!;

    [JsonPropertyName("JSDEFAULTCOUNTINGCHANNE4_40001")]
    public string Jsdefaultcountingchanne440001 { get; set; } = null!;

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
