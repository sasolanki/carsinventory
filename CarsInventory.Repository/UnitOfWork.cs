using CarsInventory.Repository.Abstract;
using CarsInventory.Repository.Concrete;

namespace CarsInventory.Repository
{
    public class UnitOfWork
    {
        /// <summary>
        /// Gets the cars inventory repository.
        /// </summary>
        /// <value>
        /// The cars inventory repository.
        /// </value>
        public ICarsInventoryRepository CarsInventoryRepository
        {
            get
            {
                return new CarsInventoryRepository();
            }
        }
    }
}
