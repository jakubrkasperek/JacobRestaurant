using JacobRestaurant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public interface IDishRepository
    {
        Task<Dish> GetById(int id);
        Task<List<Dish>> ListAll();
        Task<Dish> Add(Dish dish);
        Task Update(Dish dish);
        Task Delete(int id);
    }
}
