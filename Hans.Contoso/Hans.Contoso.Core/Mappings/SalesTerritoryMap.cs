using FluentNHibernate.Mapping;
using Hans.Contoso.Core.Domains;

namespace Hans.Contoso.Core.Mappings
{
    public class SalesTerritoryMap : ClassMap<SalesTerritory>
    {
        public SalesTerritoryMap()
        {
            Table("DimSalesTerritory");
            LazyLoad();
            Id(x => x.SalesTerritoryKey).GeneratedBy.Identity().Column("SalesTerritoryKey");
            References(x => x.Geography).Column("GeographyKey");
            Map(x => x.SalesTerritoryLabel).Column("SalesTerritoryLabel").Unique();
            Map(x => x.SalesTerritoryName).Column("SalesTerritoryName").Not.Nullable();
            Map(x => x.SalesTerritoryRegion).Column("SalesTerritoryRegion").Not.Nullable();
            Map(x => x.SalesTerritoryCountry).Column("SalesTerritoryCountry").Not.Nullable();
            Map(x => x.SalesTerritoryGroup).Column("SalesTerritoryGroup");
            Map(x => x.SalesTerritoryLevel).Column("SalesTerritoryLevel");
            Map(x => x.SalesTerritoryManager).Column("SalesTerritoryManager");
            Map(x => x.StartDate).Column("StartDate");
            Map(x => x.EndDate).Column("EndDate");
            Map(x => x.Status).Column("Status");
            Map(x => x.ETLLoadID).Column("ETLLoadID");
            Map(x => x.LoadDate).Column("LoadDate");
            Map(x => x.UpdateDate).Column("UpdateDate");
        }
    }
}
