using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        
        [Required]
        public string InventoryName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity Must Be Greater Than Or Equal To Zero")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price Must Be Greater Than Or Equal To Zero")]
        public double Price { get; set; }

        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
}
