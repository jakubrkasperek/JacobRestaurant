using System;
using System.ComponentModel.DataAnnotations;

namespace JacobRestaurant.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
    }
}
