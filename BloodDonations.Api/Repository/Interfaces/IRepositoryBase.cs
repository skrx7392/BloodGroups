using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonations.Api.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetById(object[] ids);
        T GetWithNavigational(int id, params string[] navigational);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}