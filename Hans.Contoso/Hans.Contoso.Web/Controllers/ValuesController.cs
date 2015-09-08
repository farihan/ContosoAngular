using Hans.Contoso.Core.Domains;
using Hans.Contoso.Core.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Hans.Contoso.Web.Controllers
{
    public class ValuesController : ApiController
    {
        public IRepository<Customer> CustomerRepository { get; set; }

        // GET api/values
        /// <summary>
        /// This is a test...
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            var list = CustomerRepository.FindAll();

            return list.Select(x => x.CustomerLabel).ToArray();
        }

        // GET api/values/5
        /// <summary>
        /// This is a test for get id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
