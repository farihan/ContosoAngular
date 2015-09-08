using System;

namespace Hans.Contoso.Core.Domains
{
    public class Customer
    {
        public virtual int CustomerKey { get; set; }
        public virtual Geography Geography { get; set; }
        public virtual string CustomerLabel { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool? NameStyle { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string Gender { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual decimal? YearlyIncome { get; set; }
        public virtual byte? TotalChildren { get; set; }
        public virtual byte? NumberChildrenAtHome { get; set; }
        public virtual string Education { get; set; }
        public virtual string Occupation { get; set; }
        public virtual string HouseOwnerFlag { get; set; }
        public virtual byte? NumberCarsOwned { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime? DateFirstPurchase { get; set; }
        public virtual string CustomerType { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual int? ETLLoadID { get; set; }
        public virtual DateTime? LoadDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        //public IList<FactOnlineSale> FactOnlineSales { get; set; }
    }
}
