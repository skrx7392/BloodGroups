﻿using BloodDonations.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonations.Api.Repository
{
    public interface IDatabaseFactory
    {
        BloodDonationsEntities GetBloodDonationsEntitiesContext();
    }
}
