using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonations.Api.Models;

namespace BloodDonations.Api.Repository
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private BloodDonationsEntities bloodDonationsEntitiesContext;

        public BloodDonationsEntities GetBloodDonationsEntitiesContext()
        {
            return bloodDonationsEntitiesContext ?? (bloodDonationsEntitiesContext = new BloodDonationsEntities());
        }

        protected override void DisposeCore()
        {
            if (bloodDonationsEntitiesContext != null)
                bloodDonationsEntitiesContext.Dispose();
        }
    }
}