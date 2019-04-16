using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsInventory.Data
{

    [Table("Car")]
    public partial class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool New { get; set; }

        public string UserId { get; set; }
    }
}
