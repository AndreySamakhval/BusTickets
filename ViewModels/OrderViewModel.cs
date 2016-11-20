using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class OrderViewModel
    {
        [Display(Name="Number")]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Departure time")]
        public string Departure { get; set; }
        public string Status { get; set; }

    }
}
