using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StopViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }
    }
}
