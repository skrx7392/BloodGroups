using BloodDonations.Api.Models;
using BloodDonations.Api.Repository;
using BloodDonations.Api.Repository.DbRepositories;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BloodDonations.Api.Controllers
{
    public class AccountController : ApiController
    {
        private ILoginDetailsRepository LoginDetailsRepository;
        private IDatabaseFactory DatabaseFactory;

        public AccountController()
        {
            DatabaseFactory = new DatabaseFactory();
            LoginDetailsRepository = new LoginDetailsRepository(DatabaseFactory);
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(LoginDetails loginDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bool result = LoginDetailsRepository.RegisterUser(loginDetails);
            if (result)
                return Ok();
            else
                return InternalServerError();
        }
    }
}
