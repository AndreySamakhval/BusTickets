using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModels;

namespace BusTickets.Controllers.Api
{
    public class TicketController : ApiController
    {
        Service _service = new Service();

        public TicketInfoViewModel Get(int id)
        {
            return _service.TicketInfo(id);
        }


        public int Post(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
                return _service.NewTicket(ticket);
            else return 0;
        }
    }
}
