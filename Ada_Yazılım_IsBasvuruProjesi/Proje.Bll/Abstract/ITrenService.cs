using Proje.Core.Concrate;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Bll.Abstract
{
    public interface ITrenService
    {
        ResultMessage<Tren> Add(Tren data);
        ResultMessage<Tren> Update(Tren data);
        ResultMessage<Tren> Delete(int id);
        ResultMessage<Tren> SoftDelete(int id);
        ResultMessage<ICollection<Tren>> GetAll(Expression<Func<Tren, bool>> filter = null);
        ResultMessage<Tren> Get(Expression<Func<Tren, bool>> filter);
    }
}
