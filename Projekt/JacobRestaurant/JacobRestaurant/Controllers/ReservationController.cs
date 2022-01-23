using JacobRestaurant.Models;
using JacobRestaurant.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JacobRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ViewResult> List()
        {
            return View(await _reservationRepository.ListAll());
        }

        public async Task<ViewResult> Details(int id)
        {
            return View(await _reservationRepository.GetById(id));
        }

        public async Task<ViewResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _reservationRepository.Add(reservation);
                return RedirectToAction("List");
            }
            else
                return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await _reservationRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
