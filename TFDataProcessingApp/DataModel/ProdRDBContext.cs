using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TFDataProcessingApp.Config;

namespace TFDataProcessingApp.DataModel;

public partial class ProdRDBContext : DbContext
{
    private readonly TFDataProcessingConfiguration tfDataProcessingConfiguration;

    public ProdRDBContext(TFDataProcessingConfiguration tfDataProcessingConfiguration) => this.tfDataProcessingConfiguration = tfDataProcessingConfiguration;

    public ProdRDBContext(DbContextOptions<ProdRDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Emersontracker> Emersontrackers { get; set; }

    public virtual DbSet<Geocodeyaddress> Geocodeyaddresses { get; set; }

    public virtual DbSet<Inventdim> Inventdims { get; set; }

    public virtual DbSet<Inventlocation> Inventlocations { get; set; }

    public virtual DbSet<Inventtran> Inventtrans { get; set; }

    public virtual DbSet<Jscsrreceiptmstr> Jscsrreceiptmstrs { get; set; }

    public virtual DbSet<Jsdispatchertruck> Jsdispatchertrucks { get; set; }

    public virtual DbSet<Jsvarietytable> Jsvarietytables { get; set; }

    public virtual DbSet<Tiveshipment> Tiveshipments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqlConnectionStringBuilder
        {
            DataSource = this.tfDataProcessingConfiguration.AzureSQLServer,
            InitialCatalog = this.tfDataProcessingConfiguration.AzureSQLDBName,
            MultipleActiveResultSets = true,
            Authentication = SqlAuthenticationMethod.ActiveDirectoryManagedIdentity
        }.ConnectionString;

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Recid });

            entity.ToTable("ADDRESS");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Address1)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Addrrecid).HasColumnName("ADDRRECID");
            entity.Property(e => e.Addrtableid).HasColumnName("ADDRTABLEID");
            entity.Property(e => e.Cellularphone)
                .HasMaxLength(40)
                .HasColumnName("CELLULARPHONE");
            entity.Property(e => e.City)
                .HasMaxLength(120)
                .HasColumnName("CITY");
            entity.Property(e => e.Countryregionid)
                .HasMaxLength(20)
                .HasColumnName("COUNTRYREGIONID");
            entity.Property(e => e.County)
                .HasMaxLength(20)
                .HasColumnName("COUNTY");
            entity.Property(e => e.DelRefzipcode).HasColumnName("DEL_REFZIPCODE");
            entity.Property(e => e.Email)
                .HasMaxLength(160)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Frcaraddressing)
                .HasMaxLength(500)
                .HasColumnName("FRCARADDRESSING");
            entity.Property(e => e.Jscompanyname)
                .HasMaxLength(120)
                .HasColumnName("JSCOMPANYNAME");
            entity.Property(e => e.Jscustaccountref)
                .HasMaxLength(40)
                .HasColumnName("JSCUSTACCOUNTREF");
            entity.Property(e => e.Jsfirstname)
                .HasMaxLength(40)
                .HasColumnName("JSFIRSTNAME");
            entity.Property(e => e.Jsfrommergedcust)
                .HasMaxLength(40)
                .HasColumnName("JSFROMMERGEDCUST");
            entity.Property(e => e.Jsgiftaccount)
                .HasMaxLength(40)
                .HasColumnName("JSGIFTACCOUNT");
            entity.Property(e => e.Jsisapofpo).HasColumnName("JSISAPOFPO");
            entity.Property(e => e.Jsispobox).HasColumnName("JSISPOBOX");
            entity.Property(e => e.Jslastname)
                .HasMaxLength(40)
                .HasColumnName("JSLASTNAME");
            entity.Property(e => e.Jsmiddlename)
                .HasMaxLength(2)
                .HasColumnName("JSMIDDLENAME");
            entity.Property(e => e.Jsnamesuffix).HasColumnName("JSNAMESUFFIX");
            entity.Property(e => e.Jssalutation).HasColumnName("JSSALUTATION");
            entity.Property(e => e.Jsstreet1)
                .HasMaxLength(104)
                .HasColumnName("JSSTREET1");
            entity.Property(e => e.Jsstreet2)
                .HasMaxLength(20)
                .HasColumnName("JSSTREET2");
            entity.Property(e => e.Jsstreet3)
                .HasMaxLength(104)
                .HasColumnName("JSSTREET3");
            entity.Property(e => e.Linenum)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("LINENUM");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("NAME");
            entity.Property(e => e.Pager)
                .HasMaxLength(40)
                .HasColumnName("PAGER");
            entity.Property(e => e.Phone)
                .HasMaxLength(40)
                .HasColumnName("PHONE");
            entity.Property(e => e.Phonelocal)
                .HasMaxLength(20)
                .HasColumnName("PHONELOCAL");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.Salescalendarid)
                .HasMaxLength(20)
                .HasColumnName("SALESCALENDARID");
            entity.Property(e => e.Sms)
                .HasMaxLength(160)
                .HasColumnName("SMS");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("STATE");
            entity.Property(e => e.Street)
                .HasMaxLength(500)
                .HasColumnName("STREET");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Taxgroup)
                .HasMaxLength(20)
                .HasColumnName("TAXGROUP");
            entity.Property(e => e.Telefax)
                .HasMaxLength(40)
                .HasColumnName("TELEFAX");
            entity.Property(e => e.Telex)
                .HasMaxLength(40)
                .HasColumnName("TELEX");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.Url)
                .HasMaxLength(510)
                .HasColumnName("URL");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(20)
                .HasColumnName("ZIPCODE");
        });

        modelBuilder.Entity<Emersontracker>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Trackerid }).HasName("PK__EMERSONT__2FF12D51C036455E");

            entity.ToTable("EMERSONTRACKERS");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("dataareaid");
            entity.Property(e => e.Trackerid).HasColumnName("trackerid");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Salesid)
                .HasMaxLength(40)
                .HasColumnName("salesid");
            entity.Property(e => e.Started).HasColumnName("started");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
        });

        modelBuilder.Entity<Geocodeyaddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GEOCODEY__3214EC2750E53F74");

            entity.ToTable("GEOCODEYADDRESS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Accountnum)
                .HasMaxLength(40)
                .HasColumnName("accountnum");
            entity.Property(e => e.AddressLine1).HasMaxLength(500);
            entity.Property(e => e.AddressLine2).HasMaxLength(180);
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("dataareaid");
            entity.Property(e => e.Errorcode).HasColumnName("errorcode");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(10, 6)")
                .HasColumnName("longitude");
            entity.Property(e => e.Origin).HasColumnName("origin");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Timezoneoffset).HasColumnName("timezoneoffset");
        });

        modelBuilder.Entity<Inventdim>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Inventdimid }).HasName("PK__INVENTDI__6DA6D3E270A97FF6");

            entity.ToTable("INVENTDIM");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Inventdimid)
                .HasMaxLength(40)
                .HasColumnName("INVENTDIMID");
            entity.Property(e => e.Configid)
                .HasMaxLength(20)
                .HasColumnName("CONFIGID");
            entity.Property(e => e.Inventbatchid)
                .HasMaxLength(40)
                .HasColumnName("INVENTBATCHID");
            entity.Property(e => e.Inventcolorid)
                .HasMaxLength(20)
                .HasColumnName("INVENTCOLORID");
            entity.Property(e => e.Inventlocationid)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONID");
            entity.Property(e => e.Inventserialid)
                .HasMaxLength(40)
                .HasColumnName("INVENTSERIALID");
            entity.Property(e => e.Inventsizeid)
                .HasMaxLength(20)
                .HasColumnName("INVENTSIZEID");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Wmslocationid)
                .HasMaxLength(20)
                .HasColumnName("WMSLOCATIONID");
            entity.Property(e => e.Wmspalletid)
                .HasMaxLength(36)
                .HasColumnName("WMSPALLETID");
        });

        modelBuilder.Entity<Inventlocation>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Inventlocationid }).HasName("PK__INVENTLO__DF73C48EC25D6B2E");

            entity.ToTable("INVENTLOCATION");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Inventlocationid)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONID");
            entity.Property(e => e.DelCalendardaystransfer).HasColumnName("DEL_CALENDARDAYSTRANSFER");
            entity.Property(e => e.DelLeadtimetransfer).HasColumnName("DEL_LEADTIMETRANSFER");
            entity.Property(e => e.Emptypalletlocation)
                .HasMaxLength(20)
                .HasColumnName("EMPTYPALLETLOCATION");
            entity.Property(e => e.Inventlocationidquarantine)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONIDQUARANTINE");
            entity.Property(e => e.Inventlocationidreqmain)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONIDREQMAIN");
            entity.Property(e => e.Inventlocationidtransit)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONIDTRANSIT");
            entity.Property(e => e.Inventlocationlevel).HasColumnName("INVENTLOCATIONLEVEL");
            entity.Property(e => e.Inventlocationtype).HasColumnName("INVENTLOCATIONTYPE");
            entity.Property(e => e.Jsdefaultcountingchanne240001)
                .HasMaxLength(20)
                .HasColumnName("JSDEFAULTCOUNTINGCHANNE2_40001");
            entity.Property(e => e.Jsdefaultcountingchanne340001)
                .HasMaxLength(20)
                .HasColumnName("JSDEFAULTCOUNTINGCHANNE3_40001");
            entity.Property(e => e.Jsdefaultcountingchanne440001)
                .HasMaxLength(20)
                .HasColumnName("JSDEFAULTCOUNTINGCHANNE4_40001");
            entity.Property(e => e.Jsdefaultcountingchanneld40001)
                .HasMaxLength(20)
                .HasColumnName("JSDEFAULTCOUNTINGCHANNELD40001");
            entity.Property(e => e.Jsproshipshipper)
                .HasMaxLength(40)
                .HasColumnName("JSPROSHIPSHIPPER");
            entity.Property(e => e.Manual).HasColumnName("MANUAL");
            entity.Property(e => e.Maxpickingroutetime).HasColumnName("MAXPICKINGROUTETIME");
            entity.Property(e => e.Maxpickingroutevolume)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("MAXPICKINGROUTEVOLUME");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("NAME");
            entity.Property(e => e.Pickinglinetime).HasColumnName("PICKINGLINETIME");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.Reqcalendarid)
                .HasMaxLength(20)
                .HasColumnName("REQCALENDARID");
            entity.Property(e => e.Reqrefill).HasColumnName("REQREFILL");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Usewmsorders).HasColumnName("USEWMSORDERS");
            entity.Property(e => e.Vendaccount)
                .HasMaxLength(40)
                .HasColumnName("VENDACCOUNT");
            entity.Property(e => e.Wmsaislenameactive).HasColumnName("WMSAISLENAMEACTIVE");
            entity.Property(e => e.Wmslevelformat)
                .HasMaxLength(20)
                .HasColumnName("WMSLEVELFORMAT");
            entity.Property(e => e.Wmslevelnameactive).HasColumnName("WMSLEVELNAMEACTIVE");
            entity.Property(e => e.Wmslocationiddefaultissue)
                .HasMaxLength(20)
                .HasColumnName("WMSLOCATIONIDDEFAULTISSUE");
            entity.Property(e => e.Wmslocationiddefaultreceipt)
                .HasMaxLength(20)
                .HasColumnName("WMSLOCATIONIDDEFAULTRECEIPT");
            entity.Property(e => e.Wmspositionformat)
                .HasMaxLength(20)
                .HasColumnName("WMSPOSITIONFORMAT");
            entity.Property(e => e.Wmspositionnameactive).HasColumnName("WMSPOSITIONNAMEACTIVE");
            entity.Property(e => e.Wmsrackformat)
                .HasMaxLength(20)
                .HasColumnName("WMSRACKFORMAT");
            entity.Property(e => e.Wmsracknameactive).HasColumnName("WMSRACKNAMEACTIVE");
        });

        modelBuilder.Entity<Inventtran>(entity =>
        {
            entity.HasKey(e => new { e.Inventtransid, e.Inventdimid, e.Dataareaid, e.Recid }).HasName("PK__INVENTTR__D9423D41B24BF5FA");

            entity.ToTable("INVENTTRANS");

            entity.Property(e => e.Inventtransid)
                .HasMaxLength(40)
                .HasColumnName("INVENTTRANSID");
            entity.Property(e => e.Inventdimid)
                .HasMaxLength(40)
                .HasColumnName("INVENTDIMID");
            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Costamountadjustment)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTADJUSTMENT");
            entity.Property(e => e.Costamountoperations)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTOPERATIONS");
            entity.Property(e => e.Costamountphysical)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTPHYSICAL");
            entity.Property(e => e.Costamountposted)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTPOSTED");
            entity.Property(e => e.Costamountsettled)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTSETTLED");
            entity.Property(e => e.Costamountstd)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("COSTAMOUNTSTD");
            entity.Property(e => e.Currencycode)
                .HasMaxLength(6)
                .HasColumnName("CURRENCYCODE");
            entity.Property(e => e.Custvendac)
                .HasMaxLength(40)
                .HasColumnName("CUSTVENDAC");
            entity.Property(e => e.Dateclosed)
                .HasColumnType("datetime")
                .HasColumnName("DATECLOSED");
            entity.Property(e => e.Dateexpected)
                .HasColumnType("datetime")
                .HasColumnName("DATEEXPECTED");
            entity.Property(e => e.Datefinancial)
                .HasColumnType("datetime")
                .HasColumnName("DATEFINANCIAL");
            entity.Property(e => e.Dateinvent)
                .HasColumnType("datetime")
                .HasColumnName("DATEINVENT");
            entity.Property(e => e.Datephysical)
                .HasColumnType("datetime")
                .HasColumnName("DATEPHYSICAL");
            entity.Property(e => e.Datestatus)
                .HasColumnType("datetime")
                .HasColumnName("DATESTATUS");
            entity.Property(e => e.DelJspotency)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("DEL_JSPOTENCY");
            entity.Property(e => e.Direction).HasColumnName("DIRECTION");
            entity.Property(e => e.Intercompanyinventdimtransfer3).HasColumnName("INTERCOMPANYINVENTDIMTRANSFER3");
            entity.Property(e => e.Inventdimfixed).HasColumnName("INVENTDIMFIXED");
            entity.Property(e => e.Inventreftransid)
                .HasMaxLength(40)
                .HasColumnName("INVENTREFTRANSID");
            entity.Property(e => e.Inventtransidfather)
                .HasMaxLength(40)
                .HasColumnName("INVENTTRANSIDFATHER");
            entity.Property(e => e.Inventtransidreturn)
                .HasMaxLength(40)
                .HasColumnName("INVENTTRANSIDRETURN");
            entity.Property(e => e.Invoiceid)
                .HasMaxLength(40)
                .HasColumnName("INVOICEID");
            entity.Property(e => e.Invoicereturned).HasColumnName("INVOICERETURNED");
            entity.Property(e => e.Itembomid)
                .HasMaxLength(40)
                .HasColumnName("ITEMBOMID");
            entity.Property(e => e.Itemid)
                .HasMaxLength(40)
                .HasColumnName("ITEMID");
            entity.Property(e => e.Itemrouteid)
                .HasMaxLength(40)
                .HasColumnName("ITEMROUTEID");
            entity.Property(e => e.Jscleared).HasColumnName("JSCLEARED");
            entity.Property(e => e.Jsclearedby)
                .HasMaxLength(20)
                .HasColumnName("JSCLEAREDBY");
            entity.Property(e => e.Jsdualunitqty)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSDUALUNITQTY");
            entity.Property(e => e.Jsinventreconciled).HasColumnName("JSINVENTRECONCILED");
            entity.Property(e => e.Jspotencies)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSPOTENCIES");
            entity.Property(e => e.Jspotencies2)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSPOTENCIES2_");
            entity.Property(e => e.Jspotenciesreconciled)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSPOTENCIESRECONCILED");
            entity.Property(e => e.Jspotenciesreconciled2)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSPOTENCIESRECONCILED2_");
            entity.Property(e => e.Jsqtyreconciled)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("JSQTYRECONCILED");
            entity.Property(e => e.Jsreconciledby)
                .HasMaxLength(20)
                .HasColumnName("JSRECONCILEDBY");
            entity.Property(e => e.Jsreconcilejournalid)
                .HasMaxLength(40)
                .HasColumnName("JSRECONCILEJOURNALID");
            entity.Property(e => e.Jstimeinvent).HasColumnName("JSTIMEINVENT");
            entity.Property(e => e.Jstimephysical).HasColumnName("JSTIMEPHYSICAL");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(10)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifiedtime).HasColumnName("MODIFIEDTIME");
            entity.Property(e => e.Packingslipid)
                .HasMaxLength(40)
                .HasColumnName("PACKINGSLIPID");
            entity.Property(e => e.Packingslipreturned).HasColumnName("PACKINGSLIPRETURNED");
            entity.Property(e => e.Projadjustrefid)
                .HasMaxLength(40)
                .HasColumnName("PROJADJUSTREFID");
            entity.Property(e => e.Projcategoryid)
                .HasMaxLength(20)
                .HasColumnName("PROJCATEGORYID");
            entity.Property(e => e.Projid)
                .HasMaxLength(20)
                .HasColumnName("PROJID");
            entity.Property(e => e.Qty)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("QTY");
            entity.Property(e => e.Qtysettled)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("QTYSETTLED");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.Revenueamountphysical)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("REVENUEAMOUNTPHYSICAL");
            entity.Property(e => e.Shippingdateconfirmed)
                .HasColumnType("datetime")
                .HasColumnName("SHIPPINGDATECONFIRMED");
            entity.Property(e => e.Shippingdaterequested)
                .HasColumnType("datetime")
                .HasColumnName("SHIPPINGDATEREQUESTED");
            entity.Property(e => e.Statusissue).HasColumnName("STATUSISSUE");
            entity.Property(e => e.Statusreceipt).HasColumnName("STATUSRECEIPT");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Taxamountphysical)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("TAXAMOUNTPHYSICAL");
            entity.Property(e => e.Timeexpected).HasColumnName("TIMEEXPECTED");
            entity.Property(e => e.Transchildrefid)
                .HasMaxLength(40)
                .HasColumnName("TRANSCHILDREFID");
            entity.Property(e => e.Transchildtype).HasColumnName("TRANSCHILDTYPE");
            entity.Property(e => e.Transrefid)
                .HasMaxLength(40)
                .HasColumnName("TRANSREFID");
            entity.Property(e => e.Transtype).HasColumnName("TRANSTYPE");
            entity.Property(e => e.Valueopen).HasColumnName("VALUEOPEN");
            entity.Property(e => e.Voucher)
                .HasMaxLength(40)
                .HasColumnName("VOUCHER");
            entity.Property(e => e.Voucherphysical)
                .HasMaxLength(40)
                .HasColumnName("VOUCHERPHYSICAL");
        });

        modelBuilder.Entity<Jscsrreceiptmstr>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Receiptno }).HasName("PK__JSCSRREC__C5AA607190D8C63B");

            entity.ToTable("JSCSRRECEIPTMSTR");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Receiptno)
                .HasMaxLength(24)
                .HasColumnName("RECEIPTNO");
            entity.Property(e => e.Accountnum)
                .HasMaxLength(40)
                .HasColumnName("ACCOUNTNUM");
            entity.Property(e => e.Billoflading)
                .HasMaxLength(20)
                .HasColumnName("BILLOFLADING");
            entity.Property(e => e.Comments)
                .HasColumnType("ntext")
                .HasColumnName("COMMENTS");
            entity.Property(e => e.Contract)
                .HasMaxLength(64)
                .HasColumnName("CONTRACT");
            entity.Property(e => e.Corrected).HasColumnName("CORRECTED");
            entity.Property(e => e.Createdby)
                .HasMaxLength(10)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Createdtime).HasColumnName("CREATEDTIME");
            entity.Property(e => e.Createdtransactionid).HasColumnName("CREATEDTRANSACTIONID");
            entity.Property(e => e.DelAdvancepercent)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("DEL_ADVANCEPERCENT");
            entity.Property(e => e.DelSource)
                .HasMaxLength(40)
                .HasColumnName("DEL_SOURCE");
            entity.Property(e => e.Driver)
                .HasMaxLength(40)
                .HasColumnName("DRIVER");
            entity.Property(e => e.Effective)
                .HasColumnType("datetime")
                .HasColumnName("EFFECTIVE");
            entity.Property(e => e.Fieldidtag)
                .HasMaxLength(20)
                .HasColumnName("FIELDIDTAG");
            entity.Property(e => e.Freightpaid)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("FREIGHTPAID");
            entity.Property(e => e.Freightstatus).HasColumnName("FREIGHTSTATUS");
            entity.Property(e => e.Freightvoucher)
                .HasMaxLength(40)
                .HasColumnName("FREIGHTVOUCHER");
            entity.Property(e => e.Harvesterinvoice)
                .HasMaxLength(20)
                .HasColumnName("HARVESTERINVOICE");
            entity.Property(e => e.Hauler)
                .HasMaxLength(40)
                .HasColumnName("HAULER");
            entity.Property(e => e.Itemgroupid)
                .HasMaxLength(20)
                .HasColumnName("ITEMGROUPID");
            entity.Property(e => e.Journalid)
                .HasMaxLength(40)
                .HasColumnName("JOURNALID");
            entity.Property(e => e.Jscsrinvjournalnum)
                .HasMaxLength(40)
                .HasColumnName("JSCSRINVJOURNALNUM");
            entity.Property(e => e.Jsinvsettlementjournum)
                .HasMaxLength(40)
                .HasColumnName("JSINVSETTLEMENTJOURNUM");
            entity.Property(e => e.Locationid)
                .HasMaxLength(20)
                .HasColumnName("LOCATIONID");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(10)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifiedtime).HasColumnName("MODIFIEDTIME");
            entity.Property(e => e.Modifiedtransactionid).HasColumnName("MODIFIEDTRANSACTIONID");
            entity.Property(e => e.Origreceipt)
                .HasMaxLength(24)
                .HasColumnName("ORIGRECEIPT");
            entity.Property(e => e.Purchmethod)
                .HasMaxLength(24)
                .HasColumnName("PURCHMETHOD");
            entity.Property(e => e.Receipttype).HasColumnName("RECEIPTTYPE");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.Region)
                .HasMaxLength(24)
                .HasColumnName("REGION");
            entity.Property(e => e.Rejectreceiptno)
                .HasMaxLength(24)
                .HasColumnName("REJECTRECEIPTNO");
            entity.Property(e => e.Scaleticketid)
                .HasMaxLength(40)
                .HasColumnName("SCALETICKETID");
            entity.Property(e => e.Season)
                .HasMaxLength(24)
                .HasColumnName("SEASON");
            entity.Property(e => e.Settlevalue)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("SETTLEVALUE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Trailer1)
                .HasMaxLength(40)
                .HasColumnName("TRAILER1");
            entity.Property(e => e.Trailer2)
                .HasMaxLength(40)
                .HasColumnName("TRAILER2");
            entity.Property(e => e.Truck)
                .HasMaxLength(40)
                .HasColumnName("TRUCK");
            entity.Property(e => e.Voucher)
                .HasMaxLength(40)
                .HasColumnName("VOUCHER");
        });

        modelBuilder.Entity<Jsdispatchertruck>(entity =>
        {
            entity.HasKey(e => new { e.Dataareaid, e.Recid }).HasName("PK__JSDISPAT__605C20D338F893E4");

            entity.ToTable("JSDISPATCHERTRUCKS");

            entity.Property(e => e.Dataareaid)
                .HasMaxLength(6)
                .HasColumnName("DATAAREAID");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Appointmentdate)
                .HasColumnType("datetime")
                .HasColumnName("APPOINTMENTDATE");
            entity.Property(e => e.Appointmenttime).HasColumnName("APPOINTMENTTIME");
            entity.Property(e => e.Carrier)
                .HasMaxLength(70)
                .HasColumnName("CARRIER");
            entity.Property(e => e.Checkin).HasColumnName("CHECKIN");
            entity.Property(e => e.Checkindate)
                .HasColumnType("datetime")
                .HasColumnName("CHECKINDATE");
            entity.Property(e => e.Checkintime).HasColumnName("CHECKINTIME");
            entity.Property(e => e.Checkout).HasColumnName("CHECKOUT");
            entity.Property(e => e.Checkoutdate)
                .HasColumnType("datetime")
                .HasColumnName("CHECKOUTDATE");
            entity.Property(e => e.Checkouttime).HasColumnName("CHECKOUTTIME");
            entity.Property(e => e.Createdby)
                .HasMaxLength(10)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Createdtime).HasColumnName("CREATEDTIME");
            entity.Property(e => e.Customerid)
                .HasMaxLength(40)
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Customername)
                .HasMaxLength(120)
                .HasColumnName("CUSTOMERNAME");
            entity.Property(e => e.Dlvinstructions)
                .HasMaxLength(200)
                .HasColumnName("DLVINSTRUCTIONS");
            entity.Property(e => e.Dockdoor)
                .HasMaxLength(20)
                .HasColumnName("DOCKDOOR");
            entity.Property(e => e.Drivername)
                .HasMaxLength(40)
                .HasColumnName("DRIVERNAME");
            entity.Property(e => e.Fedinsp)
                .HasMaxLength(30)
                .HasColumnName("FEDINSP");
            entity.Property(e => e.Hideloadingtimes).HasColumnName("HIDELOADINGTIMES");
            entity.Property(e => e.Inventlocationid)
                .HasMaxLength(20)
                .HasColumnName("INVENTLOCATIONID");
            entity.Property(e => e.Jsedicarrier)
                .HasMaxLength(40)
                .HasColumnName("JSEDICARRIER");
            entity.Property(e => e.Jsmasterbolid)
                .HasMaxLength(100)
                .HasColumnName("JSMASTERBOLID");
            entity.Property(e => e.Jsmod)
                .HasMaxLength(40)
                .HasColumnName("JSMOD");
            entity.Property(e => e.Jsphone)
                .HasMaxLength(40)
                .HasColumnName("JSPHONE");
            entity.Property(e => e.Licensenumber)
                .HasMaxLength(40)
                .HasColumnName("LICENSENUMBER");
            entity.Property(e => e.Licensestate)
                .HasMaxLength(20)
                .HasColumnName("LICENSESTATE");
            entity.Property(e => e.Loaddate)
                .HasColumnType("datetime")
                .HasColumnName("LOADDATE");
            entity.Property(e => e.Loadername)
                .HasMaxLength(40)
                .HasColumnName("LOADERNAME");
            entity.Property(e => e.Loading).HasColumnName("LOADING");
            entity.Property(e => e.Loadinstructions)
                .HasMaxLength(70)
                .HasColumnName("LOADINSTRUCTIONS");
            entity.Property(e => e.Loadtime).HasColumnName("LOADTIME");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(10)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIEDDATE");
            entity.Property(e => e.Modifiedtime).HasColumnName("MODIFIEDTIME");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.Route)
                .HasMaxLength(40)
                .HasColumnName("ROUTE");
            entity.Property(e => e.Rsmsmartdockguid)
                .HasMaxLength(100)
                .HasColumnName("RSMSMARTDOCKGUID");
            entity.Property(e => e.Rsmsmartdockid)
                .HasMaxLength(100)
                .HasColumnName("RSMSMARTDOCKID");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
            entity.Property(e => e.Tempinstructions)
                .HasMaxLength(70)
                .HasColumnName("TEMPINSTRUCTIONS");
            entity.Property(e => e.Tfappointmentnum)
                .HasMaxLength(40)
                .HasColumnName("TFAPPOINTMENTNUM");
            entity.Property(e => e.Tfcarriername2)
                .HasMaxLength(60)
                .HasColumnName("TFCARRIERNAME2");
            entity.Property(e => e.Tfdrivercomments2)
                .HasMaxLength(508)
                .HasColumnName("TFDRIVERCOMMENTS2");
            entity.Property(e => e.Tfdrivername2)
                .HasMaxLength(120)
                .HasColumnName("TFDRIVERNAME2");
            entity.Property(e => e.Tfdriverphone2)
                .HasMaxLength(40)
                .HasColumnName("TFDRIVERPHONE2");
            entity.Property(e => e.Tfexpdepartdate)
                .HasColumnType("datetime")
                .HasColumnName("TFEXPDEPARTDATE");
            entity.Property(e => e.Tfexpdeparttime).HasColumnName("TFEXPDEPARTTIME");
            entity.Property(e => e.Tftempinstructions2)
                .HasMaxLength(70)
                .HasColumnName("TFTEMPINSTRUCTIONS2");
            entity.Property(e => e.Truckcomments)
                .HasMaxLength(120)
                .HasColumnName("TRUCKCOMMENTS");
            entity.Property(e => e.Truckpriority).HasColumnName("TRUCKPRIORITY");
            entity.Property(e => e.Truckstatus).HasColumnName("TRUCKSTATUS");
            entity.Property(e => e.Wmslocationid)
                .HasMaxLength(20)
                .HasColumnName("WMSLOCATIONID");
        });

        modelBuilder.Entity<Jsvarietytable>(entity =>
        {
            entity.HasKey(e => e.Variety).HasName("PK__JSVARIET__8EF93A0F45C4C116");

            entity.ToTable("JSVARIETYTABLE");

            entity.Property(e => e.Variety)
                .HasMaxLength(20)
                .HasColumnName("VARIETY");
            entity.Property(e => e.Description)
                .HasMaxLength(120)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Recid).HasColumnName("RECID");
            entity.Property(e => e.Recversion).HasColumnName("RECVERSION");
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
        });

        modelBuilder.Entity<Tiveshipment>(entity =>
        {
            entity.HasKey(e => new { e.DataAreaId, e.DeviceId }).HasName("PK__TIVESHIP__0BB0907E1C5A40FC");

            entity.ToTable("TIVESHIPMENTS");

            entity.Property(e => e.DataAreaId).HasMaxLength(6);
            entity.Property(e => e.DeviceId).HasMaxLength(40);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.SalesId).HasMaxLength(40);
            entity.Property(e => e.ShipmentId).HasMaxLength(20);
            entity.Property(e => e.SyncServiceLastModifiedDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("SyncServiceLastModifiedDateUTC");
            entity.Property(e => e.SysChangeVersion).HasColumnName("SYS_CHANGE_VERSION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
