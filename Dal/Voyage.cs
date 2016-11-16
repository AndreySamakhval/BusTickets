using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    [Table("Voyage")]
    public class Voyage
    {
        public int Id { get; set; }
              
        [Required]
        public DateTime DepartureDateTime { get; set; }
        [Required]
        public DateTime ArrivalDateTime { get; set; }
        [Required]
        public TimeSpan TravelTime { get; set; }
        [Required]
        public string VoyageNumber { get; set; }
        [Required]
        public string VoyageName { get; set; }
        [Required]
        public int NumberOfSeets { get; set; }
        [Required]
        public int TicketCost { get; set; }

        [Required]
        [ForeignKey("DepartureStop")]
        public int? DepartureStopId { get; set; }
        public Stop DepartureStop { get; set; }

        [Required]
        [ForeignKey("ArriveStop")]
        public int? ArivalStopId { get; set; }
        public Stop ArriveStop { get; set; }

    }
}
