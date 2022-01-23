using System.ComponentModel.DataAnnotations;

namespace JacobRestaurant.Models
{
    public class Dish
    {
        [Required]
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
