using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akounto.Billing.Repositories
{
    public interface IBaseRepository<Model,CreateModel>
    {
        public abstract Task<string> Add(CreateModel entity);
        public abstract Task<string> Update(CreateModel entity);
        public abstract bool Delete(string ID);
        public abstract Task<Model> GetById(string ID);
        public abstract IEnumerable<Model> GetAll();
        public abstract Task<string> GetInfo( );

    }
}
