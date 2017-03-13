using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonations.Api.Models;
using BloodDonations.Api.Repository.Interfaces.DbRepositories;

namespace BloodDonations.Api.Repository.DbRepositories
{
    public class RolesRepository : RepositoryBase<Roles>, IRolesRepository
    {
        public RolesRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}