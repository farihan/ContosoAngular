using FluentNHibernate.Mapping;
using Hans.Contoso.Core.Domains;

namespace Hans.Contoso.Core.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("DimCustomer");
            LazyLoad();
            Id(x => x.CustomerKey).GeneratedBy.Identity().Column("CustomerKey");
            References(x => x.Geography).Column("GeographyKey");
            Map(x => x.CustomerLabel).Column("CustomerLabel").Not.Nullable().Unique();
            Map(x => x.Title).Column("Title");
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.MiddleName).Column("MiddleName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.NameStyle).Column("NameStyle");
            Map(x => x.BirthDate).Column("BirthDate");
            Map(x => x.MaritalStatus).Column("MaritalStatus");
            Map(x => x.Suffix).Column("Suffix");
            Map(x => x.Gender).Column("Gender");
            Map(x => x.EmailAddress).Column("EmailAddress");
            Map(x => x.YearlyIncome).Column("YearlyIncome");
            Map(x => x.TotalChildren).Column("TotalChildren");
            Map(x => x.NumberChildrenAtHome).Column("NumberChildrenAtHome");
            Map(x => x.Education).Column("Education");
            Map(x => x.Occupation).Column("Occupation");
            Map(x => x.HouseOwnerFlag).Column("HouseOwnerFlag");
            Map(x => x.NumberCarsOwned).Column("NumberCarsOwned");
            Map(x => x.AddressLine1).Column("AddressLine1");
            Map(x => x.AddressLine2).Column("AddressLine2");
            Map(x => x.Phone).Column("Phone");
            Map(x => x.DateFirstPurchase).Column("DateFirstPurchase");
            Map(x => x.CustomerType).Column("CustomerType");
            Map(x => x.CompanyName).Column("CompanyName");
            Map(x => x.ETLLoadID).Column("ETLLoadID");
            Map(x => x.LoadDate).Column("LoadDate");
            Map(x => x.UpdateDate).Column("UpdateDate");
        }
    }
}
