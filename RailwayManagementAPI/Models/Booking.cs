using System.ComponentModel.DataAnnotations;

namespace RailwayManagementAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }

        public DateTime BookingDate { get; set; }

        [Range(1, int.MaxValue)]
        public int SeatNumber { get; set; }
    }
}