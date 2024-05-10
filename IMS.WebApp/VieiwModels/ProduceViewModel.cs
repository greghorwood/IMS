using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.VieiwModels
{
    public class ProduceViewModel
    {
        [Required]
        public string productionNumber { get; set; } = string.Empty;
        
        [Required]
        [Range(minimum:1, maximum: int.MaxValue, ErrorMessage = "You have to select a product.")]
        public int ProductId { get; set; }
        
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than one.")]
        public int QuantityToProduce { get; set; }
    }
}
