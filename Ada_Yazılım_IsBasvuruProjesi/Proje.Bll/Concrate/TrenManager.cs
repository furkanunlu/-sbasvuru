using Proje.Bll.Abstract;
using Proje.Core.Concrate;
using Proje.Dal.Abstract;
using Proje.Dal.Concrate;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Bll.Concrate
{
    public class TrenManager : ITrenService
    {
        private ITrenRepository repository;
        public TrenManager(ITrenRepository _repository)
        {
            repository = _repository;
        }

        public ResultMessage<Tren> Add(Tren data) => repository.Add(data);

        public ResultMessage<Tren> Delete(int id) => repository.Delete(id);

        public ResultMessage<Tren> Get(Expression<Func<Tren, bool>> filter) => repository.Get(filter);

        public ResultMessage<ICollection<Tren>> GetAll(Expression<Func<Tren, bool>> filter = null) => repository.GetAll(filter);
        public ResultMessage<Tren> SoftDelete(int id) => repository.SoftDelete(id);

        public ResultMessage<Tren> Update(Tren data) => repository.Update(data);
    }
}
