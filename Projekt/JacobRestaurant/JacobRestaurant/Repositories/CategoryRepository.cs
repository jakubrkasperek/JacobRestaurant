using JacobRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<List<Category>> ListAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> Add(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.Find(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
