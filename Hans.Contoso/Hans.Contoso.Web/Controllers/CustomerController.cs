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
        /// <param name="sortBy">string</param>
        /// <param name="isAsc">true</param>
        /// <returns>List of customer with paging capability</returns>
        public async Task<IQueryable<CustomerModel>> GetAllBy(int page, int pageSize, string sortBy, bool isAsc)
        {
            var customers = await CustomerRepository.FindAllAsync();

            switch (sortBy.ToLower())
            {
                case "customerkey":
                    customers = isAsc ? customers.OrderBy(p => p.CustomerKey) : customers.OrderByDescending(p => p.CustomerKey);
                    break;
                case "geographykey":
                    customers = isAsc ? customers.OrderBy(p => p.Geography.GeographyKey) : customers.OrderByDescending(p => p.Geography.GeographyKey);
                    break;
                case "customerlabel":
                    customers = isAsc ? customers.OrderBy(p => p.CustomerLabel) : customers.OrderByDescending(p => p.CustomerLabel);
                    break;
                case "title":
                    customers = isAsc ? customers.OrderBy(p => p.Title) : customers.OrderByDescending(p => p.Title);
                    break;
                case "firstname":
                    customers = isAsc ? customers.OrderBy(p => p.FirstName) : customers.OrderByDescending(p => p.FirstName);
                    break;
                case "middlename":
                    customers = isAsc ? customers.OrderBy(p => p.MiddleName) : customers.OrderByDescending(p => p.MiddleName);
                    break;
                case "lastname":
                    customers = isAsc ? customers.OrderBy(p => p.LastName) : customers.OrderByDescending(p => p.LastName);
                    break;
                case "namestyle":
                    customers = isAsc ? customers.OrderBy(p => p.NameStyle) : customers.OrderByDescending(p => p.NameStyle);
                    break;
                case "birthdate":
                    customers = isAsc ? customers.OrderBy(p => p.BirthDate) : customers.OrderByDescending(p => p.BirthDate);
                    break;
                case "maritalstatus":
                    customers = isAsc ? customers.OrderBy(p => p.MaritalStatus) : customers.OrderByDescending(p => p.MaritalStatus);
                    break;
                case "suffix":
                    customers = isAsc ? customers.OrderBy(p => p.Suffix) : customers.OrderByDescending(p => p.Suffix);
                    break;
                case "gender":
                    customers = isAsc ? customers.OrderBy(p => p.Gender) : customers.OrderByDescending(p => p.Gender);
                    break;
                case "emailaddress":
                    customers = isAsc ? customers.OrderBy(p => p.EmailAddress) : customers.OrderByDescending(p => p.EmailAddress);
                    break;
                case "yearlyincome":
                    customers = isAsc ? customers.OrderBy(p => p.YearlyIncome) : customers.OrderByDescending(p => p.YearlyIncome);
                    break;
                case "totalchildren":
                    customers = isAsc ? customers.OrderBy(p => p.TotalChildren) : customers.OrderByDescending(p => p.TotalChildren);
                    break;
                case "numberchildrenathome":
                    customers = isAsc ? customers.OrderBy(p => p.NumberChildrenAtHome) : customers.OrderByDescending(p => p.NumberChildrenAtHome);
                    break;
                case "education":
                    customers = isAsc ? customers.OrderBy(p => p.Education) : customers.OrderByDescending(p => p.Education);
                    break;
                case "occupation":
                    customers = isAsc ? customers.OrderBy(p => p.Occupation) : customers.OrderByDescending(p => p.Occupation);
                    break;
                case "houseownerflag":
                    customers = isAsc ? customers.OrderBy(p => p.HouseOwnerFlag) : customers.OrderByDescending(p => p.HouseOwnerFlag);
                    break;
                case "numbercarsowned":
                    customers = isAsc ? customers.OrderBy(p => p.NumberCarsOwned) : customers.OrderByDescending(p => p.NumberCarsOwned);
                    break;
                case "addressline1":
                    customers = isAsc ? customers.OrderBy(p => p.AddressLine1) : customers.OrderByDescending(p => p.AddressLine1);
                    break;
                case "addressline2":
                    customers = isAsc ? customers.OrderBy(p => p.AddressLine2) : customers.OrderByDescending(p => p.AddressLine2);
                    break;
                case "phone":
                    customers = isAsc ? customers.OrderBy(p => p.Phone) : customers.OrderByDescending(p => p.Phone);
                    break;
                case "datefirstpurchase":
                    customers = isAsc ? customers.OrderBy(p => p.DateFirstPurchase) : customers.OrderByDescending(p => p.DateFirstPurchase);
                    break;
                case "customertype":
                    customers = isAsc ? customers.OrderBy(p => p.CustomerType) : customers.OrderByDescending(p => p.CustomerType);
                    break;
                case "companyname":
                    customers = isAsc ? customers.OrderBy(p => p.CompanyName) : customers.OrderByDescending(p => p.CompanyName);
                    break;
                case "etlloadid":
                    customers = isAsc ? customers.OrderBy(p => p.ETLLoadID) : customers.OrderByDescending(p => p.ETLLoadID);
                    break;
                case "loaddate":
                    customers = isAsc ? customers.OrderBy(p => p.LoadDate) : customers.OrderByDescending(p => p.LoadDate);
                    break;
                case "updatedate":
                    customers = isAsc ? customers.OrderBy(p => p.UpdateDate) : customers.OrderByDescending(p => p.UpdateDate);
                    break;
            }

            return customers.Select(x => new CustomerModel
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
