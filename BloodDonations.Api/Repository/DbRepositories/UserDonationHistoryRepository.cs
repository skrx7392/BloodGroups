using BloodDonations.Api.Models;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonations.Api.Repository.DbRepositories
{
    public class UserDonationHistoryRepository : RepositoryBase<UserDonationHistory>, IUserDonationHistoryRepository
    {
        public UserDonationHistoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}