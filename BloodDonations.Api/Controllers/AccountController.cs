using BloodDonations.Api.Models;
using BloodDonations.Api.Repository;
using BloodDonations.Api.Repository.DbRepositories;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;
using System.Web.Http;

namespace BloodDonations.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ILoginDetailsRepository LoginDetailsRepository;
        private readonly IDatabaseFactory DatabaseFactory;

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

        [HttpPost]
        [AllowAnonymous]
        public bool AuthenticateUser(LoginDetails loginDetails)
        {
            return ModelState.IsValid && LoginDetailsRepository.AuthenticateLogin(loginDetails);
        }
    }
}
