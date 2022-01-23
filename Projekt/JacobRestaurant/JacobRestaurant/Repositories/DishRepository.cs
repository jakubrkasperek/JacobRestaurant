using JacobRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public class DishRepository : IDishRepository
    {
        protected readonly AppDbContext _dbContext;
        public DishRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dish> GetById(int id)
        {
            return await _dbContext.Dishes.FindAsync(id);
        }

        public async Task<List<Dish>> ListAll()
        {
            return await _dbContext.Dishes.ToListAsync();
        }

        public async Task<Dish> Add(Dish dish)
        {
            _dbContext.Dishes.Add(dish);
            await _dbContext.SaveChangesAsync();
            return dish;
        }

        public async Task Delete(int id)
        {
            _dbContext.Dishes.Remove(_dbContext.Dishes.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Dish dish)
        {
            _dbContext.Entry(dish).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
