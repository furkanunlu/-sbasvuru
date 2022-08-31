using Proje.Bll.Abstract;
using Proje.Core.Concrate;
using Proje.Dal.Abstract;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Bll.Concrate
{
    public class VagonManager : IVagonService
    {
        private IVagonRepository repository;
        public VagonManager(IVagonRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Vagonlar> Add(Vagonlar data) => repository.Add(data);

        public ResultMessage<Vagonlar> Delete(int id) => repository.Delete(id);
        public ResultMessage<Vagonlar> Get(Expression<Func<Vagonlar, bool>> filter) => repository.Get(filter);

        public ResultMessage<ICollection<Vagonlar>> GetAll(Expression<Func<Vagonlar, bool>> filter = null) => repository.GetAll(filter);

        public ResultMessage<Vagonlar> SoftDelete(int id) => repository.SoftDelete(id);

        public ResultMessage<Vagonlar> Update(Vagonlar data) => repository.Update(data);
    }
}
