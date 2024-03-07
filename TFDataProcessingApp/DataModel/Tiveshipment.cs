using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Tiveshipment
{
    public DateTime Created { get; set; }

    public string DataAreaId { get; set; } = null!;

    public string SalesId { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public string ShipmentId { get; set; } = null!;

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
