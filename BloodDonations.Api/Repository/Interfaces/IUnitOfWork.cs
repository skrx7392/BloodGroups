using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonations.Api.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}