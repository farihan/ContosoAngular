using System;
using NHibernate.Search.Attributes;

namespace Hans.Contoso.Core.Domains
{
    public class SalesTerritory
    {
        [DocumentId]
        public virtual int SalesTerritoryKey { get; set; }

        public virtual Geography Geography { get; set; }

        [Field]
        public virtual string SalesTerritoryLabel { get; set; }

        [Field]
        public virtual string SalesTerritoryName { get; set; }

        [Field]
        public virtual string SalesTerritoryRegion { get; set; }

        [Field]
        public virtual string SalesTerritoryCountry { get; set; }

        [Field]
        public virtual string SalesTerritoryGroup { get; set; }

        [Field]
        public virtual string SalesTerritoryLevel { get; set; }

        public virtual int? SalesTerritoryManager { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        [Field]
        public virtual string Status { get; set; }

        public virtual int? ETLLoadID { get; set; }

        public virtual DateTime? LoadDate { get; set; }

        public virtual DateTime? UpdateDate { get; set; }
    }
}
