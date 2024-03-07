using System;
using System.Collections.Generic;

namespace TFDataProcessingApp.DataModel;

public partial class Inventtran
{
    public string Itemid { get; set; } = null!;

    public int Statusissue { get; set; }

    public int Intercompanyinventdimtransfer3 { get; set; }

    public DateTime Datephysical { get; set; }

    public decimal Qty { get; set; }

    public decimal Costamountposted { get; set; }

    public string Currencycode { get; set; } = null!;

    public int Transtype { get; set; }

    public string Transrefid { get; set; } = null!;

    public string Invoiceid { get; set; } = null!;

    public string Voucher { get; set; } = null!;

    public DateTime Dateexpected { get; set; }

    public DateTime Datefinancial { get; set; }

    public decimal Costamountphysical { get; set; }

    public string Inventtransid { get; set; } = null!;

    public int Statusreceipt { get; set; }

    public int Packingslipreturned { get; set; }

    public int Invoicereturned { get; set; }

    public string Packingslipid { get; set; } = null!;

    public string Voucherphysical { get; set; } = null!;

    public decimal Costamountadjustment { get; set; }

    public DateTime Shippingdaterequested { get; set; }

    public DateTime Shippingdateconfirmed { get; set; }

    public decimal Qtysettled { get; set; }

    public decimal Costamountsettled { get; set; }

    public int Valueopen { get; set; }

    public int Direction { get; set; }

    public DateTime Datestatus { get; set; }

    public decimal Costamountstd { get; set; }

    public DateTime Dateclosed { get; set; }

    public string Inventtransidfather { get; set; } = null!;

    public decimal Costamountoperations { get; set; }

    public string Itemrouteid { get; set; } = null!;

    public string Itembomid { get; set; } = null!;

    public string Inventtransidreturn { get; set; } = null!;

    public string Projid { get; set; } = null!;

    public string Projcategoryid { get; set; } = null!;

    public string Inventdimid { get; set; } = null!;

    public int Inventdimfixed { get; set; }

    public DateTime Dateinvent { get; set; }

    public string Custvendac { get; set; } = null!;

    public string Transchildrefid { get; set; } = null!;

    public int Transchildtype { get; set; }

    public int Timeexpected { get; set; }

    public decimal Revenueamountphysical { get; set; }

    public string Projadjustrefid { get; set; } = null!;

    public decimal Taxamountphysical { get; set; }

    public string Inventreftransid { get; set; } = null!;

    public decimal Jsdualunitqty { get; set; }

    public decimal Jspotencies { get; set; }

    public decimal Jspotencies2 { get; set; }

    public int Jsinventreconciled { get; set; }

    public int Jscleared { get; set; }

    public decimal Jsqtyreconciled { get; set; }

    public decimal Jspotenciesreconciled { get; set; }

    public decimal Jspotenciesreconciled2 { get; set; }

    public string Jsclearedby { get; set; } = null!;

    public string Jsreconciledby { get; set; } = null!;

    public string Jsreconcilejournalid { get; set; } = null!;

    public decimal DelJspotency { get; set; }

    public string Dataareaid { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }

    public DateTime Modifieddate { get; set; }

    public int Modifiedtime { get; set; }

    public string Modifiedby { get; set; } = null!;

    public int Jstimephysical { get; set; }

    public int Jstimeinvent { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
