using JacobRestaurant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacobRestaurant.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetById(int id);
        Task<List<Reservation>> ListAll();
        Task<Reservation> Add(Reservation reservation);
        Task Delete(int id);
    }
}
