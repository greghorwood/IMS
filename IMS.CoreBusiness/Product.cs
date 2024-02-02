using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity Must Be Greater Than Or Equal To Zero")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity Must Be Greater Than Or Equal To Zero")]
        public double Price { get; set; }
    }
}
