using CarsInventory.Data;
using System.Collections.Generic;

namespace CarsInventory.Repository.Abstract
{
    /// <summary>
    /// Cars inventory interface
    /// </summary>
    public interface ICarsInventoryRepository
    {
        List<Car> GetAll(string userId);
        Car Get(int Id);
        int Save(Car car);
        void Delete(int Id);
    }
}
