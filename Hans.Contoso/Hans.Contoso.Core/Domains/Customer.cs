using System;
using NHibernate.Search.Attributes;

namespace Hans.Contoso.Core.Domains
{
    [Indexed]
    public class Customer
    {
        [DocumentId]
        public virtual int CustomerKey { get; set; }

        public virtual Geography Geography { get; set; }

        [Field]
        public virtual string CustomerLabel { get; set; }

        [Field]
        public virtual string Title { get; set; }

        [Field]
        public virtual string FirstName { get; set; }

        [Field]
        public virtual string MiddleName { get; set; }

        [Field]
        public virtual string LastName { get; set; }

        [Field]
        public virtual bool? NameStyle { get; set; }

        public virtual DateTime? BirthDate { get; set; }
        [Field]
        public virtual string MaritalStatus { get; set; }

        [Field]
        public virtual string Suffix { get; set; }

        [Field]
        public virtual string Gender { get; set; }

        [Field]
        public virtual string EmailAddress { get; set; }

        public virtual decimal? YearlyIncome { get; set; }

        public virtual byte? TotalChildren { get; set; }

        public virtual byte? NumberChildrenAtHome { get; set; }

        [Field]
        public virtual string Education { get; set; }

        [Field]
        public virtual string Occupation { get; set; }

        [Field]
        public virtual string HouseOwnerFlag { get; set; }
        public virtual byte? NumberCarsOwned { get; set; }

        [Field]
        public virtual string AddressLine1 { get; set; }

        [Field]
        public virtual string AddressLine2 { get; set; }

        [Field]
        public virtual string Phone { get; set; }

        public virtual DateTime? DateFirstPurchase { get; set; }

        [Field]
        public virtual string CustomerType { get; set; }

        [Field]
        public virtual string CompanyName { get; set; }

        public virtual int? ETLLoadID { get; set; }

        public virtual DateTime? LoadDate { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        //public IList<FactOnlineSale> FactOnlineSales { get; set; }
    }
}
