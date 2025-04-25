using System.ComponentModel.DataAnnotations;

namespace Shared.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string ProductName { get; set; } = null!;

        [Range(0.01, double.MaxValue,ErrorMessage="El precio debe ser mayor que 0")]
        public double Price  { get; set; }
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "La cantidad debe ser mayor que 1.")]
        public int Quantity { get; set; }
        [Required]
        public string Location { get; set; } = null!;
    }
}
