using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Geocodeyaddress
{
    public int Id { get; set; }

    public string? Dataareaid { get; set; }

    public string? Accountnum { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public short? Timezoneoffset { get; set; }

    public bool? Origin { get; set; }

    public DateTime? Created { get; set; }

    public byte? Errorcode { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
