using Proje.Core.Concrate;
using Proje.Dal.Abstract;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Dal.Concrate
{
    public class TrenRepository : EFBaseRepository<ProjeDbContext , Tren> , ITrenRepository
    {
    }
}
