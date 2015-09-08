using Hans.Contoso.Core.Domains;
using Hans.Contoso.Core.Persistence;
using Hans.Contoso.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hans.Contoso.Web.Controllers
{
    /// <summary>
    /// Customer API
    /// </summary>
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Customer repository
        /// </summary>
        public IRepository<Customer> CustomerRepository { get; set; }

        /// <summary>
        /// Get customer count
        /// </summary>
        /// <returns>Count of all customers</returns>
        [HttpGet]
        public async Task<int> GetSize()
        {
            var products = await CustomerRepository.FindAllAsync();

            return products.Count();
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet]
        public async Task<IQueryable<CustomerModel>> GetAll()
        {
            var list = await CustomerRepository.FindAllAsync();

            return list.Select(x => new CustomerModel
            {
                CustomerKey = x.CustomerKey,
                GeographyKey = x.Geography.GeographyKey,
                CustomerLabel = x.CustomerLabel,
                Title = x.Title,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                NameStyle = x.NameStyle.HasValue ? x.NameStyle.Value : false,
                BirthDate = x.BirthDate.HasValue ? x.BirthDate.Value : DateTime.MinValue,
                MaritalStatus = x.MaritalStatus,
                Suffix = x.Suffix,
                Gender = x.Gender,
                EmailAddress = x.EmailAddress,
                YearlyIncome = x.YearlyIncome.HasValue ? x.YearlyIncome.Value : decimal.MinValue,
                TotalChildren = x.TotalChildren.HasValue ? x.TotalChildren.Value : int.MinValue,
                NumberChildrenAtHome = x.NumberChildrenAtHome.HasValue ? x.NumberChildrenAtHome.Value : int.MinValue,
                Education = x.Education,
                Occupation = x.Occupation,
                HouseOwnerFlag = x.HouseOwnerFlag,
                NumberCarsOwned = x.NumberCarsOwned.HasValue ? x.NumberCarsOwned.Value : int.MinValue,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Phone = x.Phone,
                DateFirstPurchase = x.DateFirstPurchase.HasValue ? x.DateFirstPurchase.Value : DateTime.MinValue,
                CustomerType = x.CustomerType,
                CompanyName = x.CompanyName,
                ETLLoadID = x.ETLLoadID.HasValue ? x.ETLLoadID.Value : int.MinValue,
                LoadDate = x.LoadDate.HasValue ? x.LoadDate.Value : DateTime.MinValue,
                UpdateDate = x.UpdateDate.HasValue ? x.UpdateDate.Value : DateTime.MinValue
            });
        }

        /// <summary>
        /// Get all customer filter by search
        /// </summary>
        /// <param name="search">string</param>
        /// <returns>List of customer</returns>
        [HttpGet]
        public async Task<IQueryable<CustomerModel>> GetAllBy(string search)
        {
            var list = await CustomerRepository.FindAllAsync();

            return list.Select(x => new CustomerModel
            {
                CustomerKey = x.CustomerKey,
                GeographyKey = x.Geography.GeographyKey,
                CustomerLabel = x.CustomerLabel,
                Title = x.Title,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                NameStyle = x.NameStyle.HasValue ? x.NameStyle.Value : false,
                BirthDate = x.BirthDate.HasValue ? x.BirthDate.Value : DateTime.MinValue,
                MaritalStatus = x.MaritalStatus,
                Suffix = x.Suffix,
                Gender = x.Gender,
                EmailAddress = x.EmailAddress,
                YearlyIncome = x.YearlyIncome.HasValue ? x.YearlyIncome.Value : decimal.MinValue,
                TotalChildren = x.TotalChildren.HasValue ? x.TotalChildren.Value : int.MinValue,
                NumberChildrenAtHome = x.NumberChildrenAtHome.HasValue ? x.NumberChildrenAtHome.Value : int.MinValue,
                Education = x.Education,
                Occupation = x.Occupation,
                HouseOwnerFlag = x.HouseOwnerFlag,
                NumberCarsOwned = x.NumberCarsOwned.HasValue ? x.NumberCarsOwned.Value : int.MinValue,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Phone = x.Phone,
                DateFirstPurchase = x.DateFirstPurchase.HasValue ? x.DateFirstPurchase.Value : DateTime.MinValue,
                CustomerType = x.CustomerType,
                CompanyName = x.CompanyName,
                ETLLoadID = x.ETLLoadID.HasValue ? x.ETLLoadID.Value : int.MinValue,
                LoadDate = x.LoadDate.HasValue ? x.LoadDate.Value : DateTime.MinValue,
                UpdateDate = x.UpdateDate.HasValue ? x.UpdateDate.Value : DateTime.MinValue
            });
        }

        /// <summary>
        /// Get all customer with paging capability
        /// </summary>
        /// <param name="page">int</param>
        /// <param name="pageSize">int</param>
        /// <param name="sort">string</param>
        /// <param name="asc">true</param>
        /// <returns>List of customer with paging capability</returns>
        public async Task<IQueryable<CustomerModel>> GetAllBy(int page, int pageSize, string sort = "customerkey", bool asc = true)
        {
            var dimcutomers = await CustomerRepository.FindAllAsync();

            switch (sort.ToLower())
            {
                case "customerkey":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.CustomerKey) : dimcutomers.OrderByDescending(p => p.CustomerKey);
                    break;
                case "geographykey":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Geography.GeographyKey) : dimcutomers.OrderByDescending(p => p.Geography.GeographyKey);
                    break;
                case "customerlabel":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.CustomerLabel) : dimcutomers.OrderByDescending(p => p.CustomerLabel);
                    break;
                case "title":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Title) : dimcutomers.OrderByDescending(p => p.Title);
                    break;
                case "firstname":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.FirstName) : dimcutomers.OrderByDescending(p => p.FirstName);
                    break;
                case "middlename":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.MiddleName) : dimcutomers.OrderByDescending(p => p.MiddleName);
                    break;
                case "lastname":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.LastName) : dimcutomers.OrderByDescending(p => p.LastName);
                    break;
                case "namestyle":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.NameStyle) : dimcutomers.OrderByDescending(p => p.NameStyle);
                    break;
                case "birthdate":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.BirthDate) : dimcutomers.OrderByDescending(p => p.BirthDate);
                    break;
                case "maritalstatus":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.MaritalStatus) : dimcutomers.OrderByDescending(p => p.MaritalStatus);
                    break;
                case "suffix":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Suffix) : dimcutomers.OrderByDescending(p => p.Suffix);
                    break;
                case "gender":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Gender) : dimcutomers.OrderByDescending(p => p.Gender);
                    break;
                case "emailaddress":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.EmailAddress) : dimcutomers.OrderByDescending(p => p.EmailAddress);
                    break;
                case "yearlyincome":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.YearlyIncome) : dimcutomers.OrderByDescending(p => p.YearlyIncome);
                    break;
                case "totalchildren":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.TotalChildren) : dimcutomers.OrderByDescending(p => p.TotalChildren);
                    break;
                case "numberchildrenathome":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.NumberChildrenAtHome) : dimcutomers.OrderByDescending(p => p.NumberChildrenAtHome);
                    break;
                case "education":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Education) : dimcutomers.OrderByDescending(p => p.Education);
                    break;
                case "occupation":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Occupation) : dimcutomers.OrderByDescending(p => p.Occupation);
                    break;
                case "houseownerflag":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.HouseOwnerFlag) : dimcutomers.OrderByDescending(p => p.HouseOwnerFlag);
                    break;
                case "numbercarsowned":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.NumberCarsOwned) : dimcutomers.OrderByDescending(p => p.NumberCarsOwned);
                    break;
                case "addressline1":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.AddressLine1) : dimcutomers.OrderByDescending(p => p.AddressLine1);
                    break;
                case "addressline2":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.AddressLine2) : dimcutomers.OrderByDescending(p => p.AddressLine2);
                    break;
                case "phone":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.Phone) : dimcutomers.OrderByDescending(p => p.Phone);
                    break;
                case "datefirstpurchase":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.DateFirstPurchase) : dimcutomers.OrderByDescending(p => p.DateFirstPurchase);
                    break;
                case "customertype":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.CustomerType) : dimcutomers.OrderByDescending(p => p.CustomerType);
                    break;
                case "companyname":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.CompanyName) : dimcutomers.OrderByDescending(p => p.CompanyName);
                    break;
                case "etlloadid":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.ETLLoadID) : dimcutomers.OrderByDescending(p => p.ETLLoadID);
                    break;
                case "loaddate":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.LoadDate) : dimcutomers.OrderByDescending(p => p.LoadDate);
                    break;
                case "updatedate":
                    dimcutomers = asc ? dimcutomers.OrderBy(p => p.UpdateDate) : dimcutomers.OrderByDescending(p => p.UpdateDate);
                    break;
            }

            return dimcutomers.Select(x => new CustomerModel
            {
                CustomerKey = x.CustomerKey,
                GeographyKey = x.Geography.GeographyKey,
                CustomerLabel = x.CustomerLabel,
                Title = x.Title,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                NameStyle = x.NameStyle.HasValue ? x.NameStyle.Value : false,
                BirthDate = x.BirthDate.HasValue ? x.BirthDate.Value : DateTime.MinValue,
                MaritalStatus = x.MaritalStatus,
                Suffix = x.Suffix,
                Gender = x.Gender,
                EmailAddress = x.EmailAddress,
                YearlyIncome = x.YearlyIncome.HasValue ? x.YearlyIncome.Value : decimal.MinValue,
                TotalChildren = x.TotalChildren.HasValue ? x.TotalChildren.Value : int.MinValue,
                NumberChildrenAtHome = x.NumberChildrenAtHome.HasValue ? x.NumberChildrenAtHome.Value : int.MinValue,
                Education = x.Education,
                Occupation = x.Occupation,
                HouseOwnerFlag = x.HouseOwnerFlag,
                NumberCarsOwned = x.NumberCarsOwned.HasValue ? x.NumberCarsOwned.Value : int.MinValue,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Phone = x.Phone,
                DateFirstPurchase = x.DateFirstPurchase.HasValue ? x.DateFirstPurchase.Value : DateTime.MinValue,
                CustomerType = x.CustomerType,
                CompanyName = x.CompanyName,
                ETLLoadID = x.ETLLoadID.HasValue ? x.ETLLoadID.Value : int.MinValue,
                LoadDate = x.LoadDate.HasValue ? x.LoadDate.Value : DateTime.MinValue,
                UpdateDate = x.UpdateDate.HasValue ? x.UpdateDate.Value : DateTime.MinValue
            }).Skip((page - 1) * pageSize).Take(pageSize);
        }

        //// GET: api/Customer
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Customer/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Customer
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Customer/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Customer/5
        //public void Delete(int id)
        //{
        //}
    }
}
