using JacobRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        protected readonly AppDbContext _dbContext;
        public ReservationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _dbContext.Reservations.FindAsync(id);
        }

        public async Task<List<Reservation>> ListAll()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation;
        }

        public async Task Delete(int id)
        {
            _dbContext.Reservations.Remove(_dbContext.Reservations.Find(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
