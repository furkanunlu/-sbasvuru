using Microsoft.EntityFrameworkCore;
using Proje.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Core.Concrate
{
    public class EFBaseRepository<TContext, TEntity> : IEFBaseRepository<TEntity>
    where TEntity : class, IData, new()
    where TContext : DbContext, new()
    {
        public ResultMessage<TEntity> Add(TEntity data)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var addedData = context.Entry(data);
                    addedData.State = EntityState.Added;
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { isTrue = false, Data = null, Message = "Kayıt Eklenemedi." } :
                        new ResultMessage<TEntity> { isTrue = true, Data = data, Message = "Kayıt eklenmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { isTrue = false, Data = null, Message = ex.Message };
            }
        }

        public ResultMessage<TEntity> Delete(int id)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var data = context.Set<TEntity>().Find(id);
                    var deletedData = context.Entry(data);
                    deletedData.State = EntityState.Deleted;
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { isTrue = false, Data = null, Message = "Kayıt Silinemedi." } :
                        new ResultMessage<TEntity> { isTrue = true, Data = data, Message = "Kayıt silinmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { isTrue = false, Data = null, Message = ex.Message };
            }
        }
        public ResultMessage<TEntity> SoftDelete(int id)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var data = context.Set<TEntity>().Find(id);
                    var deletedData = context.Entry(data);
                    data.isDelete = true;
                    deletedData.State = EntityState.Modified;
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { isTrue = false, Data = null, Message = "Kayıt Silinemedi." } :
                        new ResultMessage<TEntity> { isTrue = true, Data = data, Message = "Kayıt silinmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { isTrue = false, Data = null, Message = ex.Message };
            }
        }

        public ResultMessage<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    TEntity data = context.Set<TEntity>().FirstOrDefault(filter);
                    return data == null ? new ResultMessage<TEntity> { isTrue = false, Data = null, Message = "Aranan kriterlere uygun kayıt bulunamadı" } :
                        new ResultMessage<TEntity> { isTrue = true, Data = data, Message = "Kayıt getirildi." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { isTrue = false, Data = null, Message = ex.Message };
            }
        }

        public ResultMessage<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    ICollection<TEntity> dataList;
                    if (filter == null)
                    {
                        dataList = context.Set<TEntity>().Where(x => !x.isDelete).ToList();
                    }
                    else
                    {
                        dataList = context.Set<TEntity>().Where(filter).ToList();
                    }
                    return new ResultMessage<ICollection<TEntity>> { isTrue = true, Data = dataList, Message = "Veriler listelendi." };

                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<ICollection<TEntity>> { isTrue = false, Data = null, Message = ex.Message };
            }
        }

        public ResultMessage<TEntity> Update(TEntity data)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var updatedData = context.Entry(data);
                    updatedData.State = EntityState.Modified;
                    int result = context.SaveChanges();
                    return result == 0 ? new ResultMessage<TEntity> { isTrue = false, Data = null, Message = "Kayıt Güncellendi." } :
                        new ResultMessage<TEntity> { isTrue = true, Data = data, Message = "Kayıt Güncellenmeye hazır." };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<TEntity> { isTrue = false, Data = null, Message = ex.Message };
            }
        }
    }
}
