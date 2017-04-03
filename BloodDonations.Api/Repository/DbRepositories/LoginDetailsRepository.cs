using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonations.Api.Models;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;
using System.Threading.Tasks;

namespace BloodDonations.Api.Repository.DbRepositories
{
    public class LoginDetailsRepository : RepositoryBase<LoginDetails>, ILoginDetailsRepository
    {
        private IUnitOfWork UnitOfWork;
        public LoginDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            UnitOfWork = new UnitOfWork(databaseFactory);
        }

        public bool RegisterUser(LoginDetails loginDetails)
        {
            var userExists = this.GetAll().FirstOrDefault(p => p.Username == loginDetails.Username);
            if (userExists != null)
                return false;
            try
            {
                this.Add(loginDetails);
                this.UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AuthenticateLogin(LoginDetails loginDetails)
        {
            var user = this.GetAll().FirstOrDefault(p => p.Username == loginDetails.Username);
            return user != null && user.Password == loginDetails.Password;
        }
    }
}