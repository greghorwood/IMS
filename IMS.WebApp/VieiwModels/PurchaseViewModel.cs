﻿using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.VieiwModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PONumber { get; set; } = string.Empty;
        
        [Required]
        [Range(minimum:1, maximum: int.MaxValue, ErrorMessage = "You have to select an inventory")]
        public int InventoryId { get; set; }
        
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than one.")]
        public int QuantityToPurchase { get; set; }
        public double InventoryPrice { get; set; }
    }
}
