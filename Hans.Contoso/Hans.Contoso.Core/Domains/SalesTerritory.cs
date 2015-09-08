using System;

namespace Hans.Contoso.Core.Domains
{
    public class SalesTerritory
    {
        public virtual int SalesTerritoryKey { get; set; }
        public virtual Geography Geography { get; set; }
        public virtual string SalesTerritoryLabel { get; set; }
        public virtual string SalesTerritoryName { get; set; }
        public virtual string SalesTerritoryRegion { get; set; }
        public virtual string SalesTerritoryCountry { get; set; }
        public virtual string SalesTerritoryGroup { get; set; }
        public virtual string SalesTerritoryLevel { get; set; }
        public virtual int? SalesTerritoryManager { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string Status { get; set; }
        public virtual int? ETLLoadID { get; set; }
        public virtual DateTime? LoadDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }
}
