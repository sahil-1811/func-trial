using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Jsdispatchertruck
{
    public string? Route { get; set; }

    public string? Carrier { get; set; }

    public string? Dlvinstructions { get; set; }

    public string? Loadinstructions { get; set; }

    public string? Licensenumber { get; set; }

    public string? Licensestate { get; set; }

    public string? Drivername { get; set; }

    public string? Truckcomments { get; set; }

    public string? Fedinsp { get; set; }

    public string? Tempinstructions { get; set; }

    public string? Loadername { get; set; }

    public string? Dockdoor { get; set; }

    public int? Appointmenttime { get; set; }

    public DateTime? Checkindate { get; set; }

    public int? Checkin { get; set; }

    public int? Checkintime { get; set; }

    public int? Loading { get; set; }

    public DateTime? Loaddate { get; set; }

    public int? Loadtime { get; set; }

    public int? Checkout { get; set; }

    public DateTime? Checkoutdate { get; set; }

    public int? Checkouttime { get; set; }

    public int? Truckstatus { get; set; }

    public DateTime? Appointmentdate { get; set; }

    public string? Inventlocationid { get; set; }

    public string? Customerid { get; set; }

    public string? Customername { get; set; }

    public int? Truckpriority { get; set; }

    public int? Hideloadingtimes { get; set; }

    public string? Wmslocationid { get; set; }

    public string? Jsphone { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Modifiedtime { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? Createddate { get; set; }

    public int? Createdtime { get; set; }

    public string? Createdby { get; set; }

    public string Dataareaid { get; set; } = null!;

    public int? Recversion { get; set; }

    public long Recid { get; set; }

    public string? Jsmasterbolid { get; set; }

    public string? Jsedicarrier { get; set; }

    public string? Jsmod { get; set; }

    public string? Rsmsmartdockid { get; set; }

    public string? Rsmsmartdockguid { get; set; }

    public DateTime? Tfexpdepartdate { get; set; }

    public int? Tfexpdeparttime { get; set; }

    public string? Tfcarriername2 { get; set; }

    public string? Tfdrivername2 { get; set; }

    public string? Tfdriverphone2 { get; set; }

    public string? Tfdrivercomments2 { get; set; }

    public string? Tftempinstructions2 { get; set; }

    public string? Tfappointmentnum { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
