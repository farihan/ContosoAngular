using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.Contoso.Web.Models
{
    /// <summary>
    /// Customer model
    /// </summary>
    public class CustomerModel
    {
        public int CustomerKey { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int GeographyKey { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string CustomerLabel { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public bool NameStyle { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Suffix { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^[0-9]+(\.[0-9]+)?$", ErrorMessage="Enter decimal numbers only")]
        public decimal YearlyIncome { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage="Enter numbers only")]
        public int TotalChildren { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage="Enter numbers only")]
        public int NumberChildrenAtHome { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Education { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string HouseOwnerFlag { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage="Enter numbers only")]
        public int NumberCarsOwned { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime DateFirstPurchase { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string CustomerType { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage="Enter numbers only")]
        public int ETLLoadID { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime LoadDate { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime UpdateDate { get; set; }

        //public DimGeography DimGeography { get; set; }
        //public IList<FactOnlineSale> FactOnlineSaleses { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Sort { get; set; }
        public bool IsAsc { get; set; }
        //public IList<DimCutomer> DimCutomers { get; set; }

        /// <summary>
        /// Customer model constructor
        /// </summary>
        public CustomerModel()
        {
            TotalPages = 0;
            CurrentPage = 0;
            PageSize = 0;
            PageIndex = 0;
        }
    }
}
