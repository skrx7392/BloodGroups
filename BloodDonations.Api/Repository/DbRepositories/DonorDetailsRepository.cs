using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonations.Api.Models;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;

namespace BloodDonations.Api.Repository.DbRepositories
{
    public class DonorDetailsRepository : RepositoryBase<DonorDetails>, IDonorDetailsRepository
    {
        public DonorDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}