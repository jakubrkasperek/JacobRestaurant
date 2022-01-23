using JacobRestaurant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);
        Task<List<Category>> ListAll();
        Task<Category> Add(Category category);
        Task Delete(int id);
    }
}
