using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SearchVoyageViewModel
    {
        [Required]        
        public int DepartureId { get; set; }
        [Required]
        public int ArriveId { get; set; }
        [Required]
        public string Date{ get; set; }
    }
}
