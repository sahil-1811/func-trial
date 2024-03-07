using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Emersontracker
{
    public string Dataareaid { get; set; } = null!;

    public string Salesid { get; set; } = null!;

    public long Trackerid { get; set; }

    public bool Started { get; set; }

    public DateTime Created { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
