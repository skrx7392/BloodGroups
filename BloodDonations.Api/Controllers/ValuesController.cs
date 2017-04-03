using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloodDonations.Api.Models;

namespace BloodDonations.Api.Controllers
{
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Get values 
        /// </summary>
        /// <returns>IEnumerable of string</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        public bool Post([FromBody]LoginDetails loginDetails)
        {
            return new AccountController().AuthenticateUser(loginDetails);
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
