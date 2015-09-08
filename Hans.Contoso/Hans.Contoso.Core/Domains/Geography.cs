using System;
using System.Collections.Generic;

namespace Hans.Contoso.Core.Domains
{
    public class Geography
    {
        public virtual int GeographyKey { get; set; }
        public virtual string GeographyType { get; set; }
        public virtual string ContinentName { get; set; }
        public virtual string CityName { get; set; }
        public virtual string StateProvinceName { get; set; }
        public virtual string RegionCountryName { get; set; }
        public virtual string Geometry { get; set; }
        public virtual int? ETLLoadID { get; set; }
        public virtual DateTime? LoadDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual IList<Customer> Customers { get; set; }
        public virtual IList<SalesTerritory> SaleTerritories { get; set; }
    }
}
