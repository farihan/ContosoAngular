using System;
using System.Collections.Generic;
using NHibernate.Search.Attributes;

namespace Hans.Contoso.Core.Domains
{
    public class Geography
    {
        [DocumentId]
        public virtual int GeographyKey { get; set; }

        [Field]
        public virtual string GeographyType { get; set; }

        [Field]
        public virtual string ContinentName { get; set; }

        [Field]
        public virtual string CityName { get; set; }

        [Field]
        public virtual string StateProvinceName { get; set; }

        [Field]
        public virtual string RegionCountryName { get; set; }

        [Field]
        public virtual string Geometry { get; set; }

        public virtual int? ETLLoadID { get; set; }

        public virtual DateTime? LoadDate { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        public virtual IList<Customer> Customers { get; set; }

        public virtual IList<SalesTerritory> SaleTerritories { get; set; }
    }
}
