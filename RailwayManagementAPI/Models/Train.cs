using System.ComponentModel.DataAnnotations;

namespace RailwayManagementAPI.Models
{
    public class Train
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartureStation { get; set; }

        [Required]
        [StringLength(50)]
        public string ArrivalStation { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}