﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SabaVEE2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SabaCandHEntities : DbContext
    {
        public SabaCandHEntities()
            : base("name=SabaCandHEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Button> Buttons { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Catchment> Catchments { get; set; }
        public virtual DbSet<ChangeDB> ChangeDBs { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreateTokenByDongle> CreateTokenByDongles { get; set; }
        public virtual DbSet<Curve> Curves { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DangelInfo> DangelInfoes { get; set; }
        public virtual DbSet<DataBasesInfo> DataBasesInfoes { get; set; }
        public virtual DbSet<DeviceModel> DeviceModels { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<EOffice> EOffices { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<ESubOffice> ESubOffices { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MessageText> MessageTexts { get; set; }
        public virtual DbSet<Meter> Meters { get; set; }
        public virtual DbSet<MeterError> MeterErrors { get; set; }
        public virtual DbSet<Modem> Modems { get; set; }
        public virtual DbSet<OBISS> OBISSes { get; set; }
        public virtual DbSet<OBISType> OBISTypes { get; set; }
        public virtual DbSet<OBISUnit> OBISUnits { get; set; }
        public virtual DbSet<OBISValueDetail> OBISValueDetails { get; set; }
        public virtual DbSet<OBISValueHeader> OBISValueHeaders { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OldOBISs> OldOBISses { get; set; }
        public virtual DbSet<Plain> Plains { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<regulationRule> regulationRules { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SoftversionToDeviceModel> SoftversionToDeviceModels { get; set; }
        public virtual DbSet<SourceType> SourceTypes { get; set; }
        public virtual DbSet<SubOffice> SubOffices { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<TokenFromDangle> TokenFromDangles { get; set; }
        public virtual DbSet<Translate> Translates { get; set; }
        public virtual DbSet<UnitGroup> UnitGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<ButtonAccess> ButtonAccesses { get; set; }
        public virtual DbSet<CardToMeter> CardToMeters { get; set; }
        public virtual DbSet<ConsumedActiveEnergy> ConsumedActiveEnergies { get; set; }
        public virtual DbSet<ConsumedMaxDemand> ConsumedMaxDemands { get; set; }
        public virtual DbSet<ConsumedWater> ConsumedWaters { get; set; }
        public virtual DbSet<Credit303> Credit303 { get; set; }
        public virtual DbSet<FixedOBI> FixedOBIS { get; set; }
        public virtual DbSet<GroupToProvince> GroupToProvinces { get; set; }
        public virtual DbSet<HashToGroup> HashToGroups { get; set; }
        public virtual DbSet<MeterToCustomer> MeterToCustomers { get; set; }
        public virtual DbSet<MeterToGroup> MeterToGroups { get; set; }
        public virtual DbSet<MonthName> MonthNames { get; set; }
        public virtual DbSet<OBISToReport> OBISToReports { get; set; }
        public virtual DbSet<OBISToSoftversion> OBISToSoftversions { get; set; }
        public virtual DbSet<ObjectofWindow> ObjectofWindows { get; set; }
        public virtual DbSet<RegionalOffice> RegionalOffices { get; set; }
        public virtual DbSet<StatusOBISsDesc> StatusOBISsDescs { get; set; }
        public virtual DbSet<TempMeter1> TempMeter1 { get; set; }
        public virtual DbSet<TempSaba> TempSabas { get; set; }
        public virtual DbSet<UserToGroup> UserToGroups { get; set; }
    }
}
