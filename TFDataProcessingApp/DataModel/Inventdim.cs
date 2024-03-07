using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Inventdim
{
    public string Inventdimid { get; set; } = null!;

    public string Inventbatchid { get; set; } = null!;

    public string Wmslocationid { get; set; } = null!;

    public string Wmspalletid { get; set; } = null!;

    public string Inventserialid { get; set; } = null!;

    public string Inventlocationid { get; set; } = null!;

    public string Configid { get; set; } = null!;

    public string Inventsizeid { get; set; } = null!;

    public string Inventcolorid { get; set; } = null!;

    public string Dataareaid { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
