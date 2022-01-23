using System.ComponentModel.DataAnnotations;

namespace JacobRestaurant.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}
