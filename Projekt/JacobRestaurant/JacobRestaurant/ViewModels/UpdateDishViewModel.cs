using JacobRestaurant.Models;
using System.Collections.Generic;

namespace JacobRestaurant.ViewModels
{
    public class UpdateDishViewModel
    {
        public Dish Dish { get; set; }
        public List<Category> Categories { get; set; }
    }
}
