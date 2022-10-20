using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;
namespace DataAccess.Abstract
{
   public interface IEntityRepository <T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //linq filtreleme işlemlerini yapmasını sağlar -->"Expression<Func<T, bool>> filter = null"
        T Get(Expression<Func<T, bool>> filter);
        void Added(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
