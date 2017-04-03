using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonations.Api.Models;

namespace BloodDonations.Api.Repository.Interfaces.DbRepositories
{
    public interface ILoginDetailsRepository : IRepositoryBase<LoginDetails>
    {
        bool RegisterUser(LoginDetails loginDetails);
        bool AuthenticateLogin(LoginDetails loginDetails);
    }
}
