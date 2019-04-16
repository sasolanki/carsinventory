using CarsInventory.Data;
using CarsInventory.Repository.Abstract;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarsInventory.Repository.Concrete
{
    public class CarsInventoryRepository : ICarsInventoryRepository
    {
        CarsInventoryContext context;

        public CarsInventoryRepository()
        {
            context = new CarsInventoryContext();
        }
        public void Delete(int Id)
        {
            var deleteObj = context.Cars.Find(Id);
            if (deleteObj != null)
            {
                context.Cars.Remove(deleteObj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Car Get(int Id)
        {
            return context.Cars.Find(Id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public List<Car> GetAll(string userId)
        {
            return context.Cars.Where(c => c.UserId == userId).ToList();
        }

        /// <summary>
        /// Saves the specified car.
        /// </summary>
        /// <param name="car">The car.</param>
        /// <returns></returns>
        public int Save(Car car)
        {
            if(car.Id>0)
            {
                context.Entry(car).State = EntityState.Modified;
            }
            else
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();
            return car.Id;
        }
    }
}
