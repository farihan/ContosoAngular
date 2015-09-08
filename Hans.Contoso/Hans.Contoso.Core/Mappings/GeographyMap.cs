using FluentNHibernate.Mapping;
using Hans.Contoso.Core.Domains;

namespace Hans.Contoso.Core.Mappings
{
    public class GeographyMap : ClassMap<Geography>
    {
        public GeographyMap()
        {
            Table("DimGeography");
            LazyLoad();
            Id(x => x.GeographyKey).GeneratedBy.Identity().Column("GeographyKey");
            Map(x => x.GeographyType).Column("GeographyType").Not.Nullable();
            Map(x => x.ContinentName).Column("ContinentName").Not.Nullable();
            Map(x => x.CityName).Column("CityName");
            Map(x => x.StateProvinceName).Column("StateProvinceName");
            Map(x => x.RegionCountryName).Column("RegionCountryName");
            Map(x => x.Geometry).Column("Geometry");
            Map(x => x.ETLLoadID).Column("ETLLoadID");
            Map(x => x.LoadDate).Column("LoadDate");
            Map(x => x.UpdateDate).Column("UpdateDate");
        }
    }
}
