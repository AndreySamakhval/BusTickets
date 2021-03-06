﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TicketInfoViewModel
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public int OrderId { get; set; }
        public string DocumentNumber { get; set; }
        public string NumberSeet { get; set; }
        public string Status { get; set; }
        public string VoyageNumeber { get; set; }
        public string VoyageName { get; set; }
        public DateTime Departure { get; set; }
    }
}
