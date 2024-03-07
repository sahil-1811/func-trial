using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Jsvarietytable
{
    public string Variety { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
