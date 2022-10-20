using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Added(Car entity)
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var AddedCar = context.Entry(entity);
                AddedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var DeletedCar = context.Entry(entity);
                DeletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                return filter == null ?  //filtre varsa filtreye göre listeler filtre yoksa hepsini olduğu gibi listeler.
                    context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList();   
            }
        }

        public void Update(Car entity)
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
