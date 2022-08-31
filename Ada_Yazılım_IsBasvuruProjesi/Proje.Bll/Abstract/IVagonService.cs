using Proje.Core.Concrate;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Bll.Abstract
{
    public interface IVagonService
    {
        ResultMessage<Vagonlar> Add(Vagonlar data);
        ResultMessage<Vagonlar> Update(Vagonlar data);
        ResultMessage<Vagonlar> Delete(int id);
        ResultMessage<Vagonlar> SoftDelete(int id);
        ResultMessage<ICollection<Vagonlar>> GetAll(Expression<Func<Vagonlar, bool>> filter = null);
        ResultMessage<Vagonlar> Get(Expression<Func<Vagonlar, bool>> filter);
    }
}
