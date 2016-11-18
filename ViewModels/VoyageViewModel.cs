using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VoyageViewModel
    {
        //[Display(Name = "Name")]
        public int Id { get; set; }
        public string Name { get; set; }            
        public string Number { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public TimeSpan TravelTime { get; set; }
        public int NumberSeats { get; set; }
        public int OneTicketCost { get; set; }
    }
}
