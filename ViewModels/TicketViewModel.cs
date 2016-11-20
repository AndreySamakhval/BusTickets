using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PassengerName { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public string NumberSeet { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
