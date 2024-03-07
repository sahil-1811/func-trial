using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TFDataProcessingApp.DataModel;

public partial class Address
{
    public int Addrtableid { get; set; }

    public long Addrrecid { get; set; }

    public decimal Linenum { get; set; }

    public int Type { get; set; }

    public string Name { get; set; } = null!;

    [JsonPropertyName("Address")]
    public string Address1 { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Telefax { get; set; } = null!;

    public string Countryregionid { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string State { get; set; } = null!;

    public string County { get; set; } = null!;

    public string Telex { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Phonelocal { get; set; } = null!;

    public string Cellularphone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Taxgroup { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Pager { get; set; } = null!;

    public string Sms { get; set; } = null!;

    public long DelRefzipcode { get; set; }

    public string Salescalendarid { get; set; } = null!;

    public string Frcaraddressing { get; set; } = null!;

    public string Jsfirstname { get; set; } = null!;

    public string Jsmiddlename { get; set; } = null!;

    public string Jslastname { get; set; } = null!;

    public int Jssalutation { get; set; }

    public int Jsnamesuffix { get; set; }

    public string Jsstreet1 { get; set; } = null!;

    public string Jsstreet2 { get; set; } = null!;

    public string Jsstreet3 { get; set; } = null!;

    public string Jscompanyname { get; set; } = null!;

    public string Jsgiftaccount { get; set; } = null!;

    public int Jsispobox { get; set; }

    public int Jsisapofpo { get; set; }

    public string Jsfrommergedcust { get; set; } = null!;

    public string Jscustaccountref { get; set; } = null!;

    public string Dataareaid { get; set; } = null!;

    public int Recversion { get; set; }

    public long Recid { get; set; }

    public long SysChangeVersion { get; set; }

    public DateTime SyncServiceLastModifiedDateUtc { get; set; }
}
