using BloodDonations.Api.Models;
using BloodDonations.Api.Repository;
using BloodDonations.Api.Repository.DbRepositories;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BloodDonations.Api
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            IDatabaseFactory databaseFactory = new DatabaseFactory();
            ILoginDetailsRepository loginDetailsRepository = new LoginDetailsRepository(databaseFactory);
            LoginDetails userLogin = loginDetailsRepository.GetAll().FirstOrDefault(p => p.Username.Equals(context.UserName));
            if (userLogin == null)
            {
                context.SetError("invalid_grant", "The username or password is incorrect.");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}