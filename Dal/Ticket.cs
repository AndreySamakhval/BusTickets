using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    [Table("Ticket")]
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerDocumentNumber { get; set; }
        [Required]
        public string SeetNumber { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
