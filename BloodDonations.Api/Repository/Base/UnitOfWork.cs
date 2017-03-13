using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace BloodDonations.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private DbContext bloodDonationsEntitiesContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected DbContext BloodDonationsEntitiesContext
        {
            get { return bloodDonationsEntitiesContext ?? (bloodDonationsEntitiesContext = databaseFactory.GetBloodDonationsEntitiesContext()); }
        }

        public void Commit()
        {
            try
            {
                BloodDonationsEntitiesContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var validationErrors = ex.EntityValidationErrors.SelectMany(p => p.ValidationErrors).Select(e => e.ErrorMessage);
                var exceptionMessage = string.Concat(ex.Message, "; Validation Errors: ", string.Join("; ", validationErrors));
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}