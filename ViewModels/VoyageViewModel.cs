using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VoyageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]       
        public string Departure { get; set; }
        [Required]        
        public string Arrival { get; set; }
        [Required]        
        public string TravelTime { get; set; }
        [Required]
        public int NumberSeats { get; set; }
        [Required]
        public int OneTicketCost { get; set; }
    }
}
