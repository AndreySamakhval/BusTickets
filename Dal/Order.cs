using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Voyage")]
        public int VoyageId { get; set; }
        public Voyage Voyage { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Status { get; set; }

    }
}
