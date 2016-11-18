using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace BusTickets.Controllers
{
    public class OrderController : Controller
    {
        Service _service = new Service();
        // GET: Order
        public ActionResult Index(int id)
        {
           VoyageViewModel voyage =_service.GetVoyage(id);

            return View(voyage);
        }
        //[HttpPost]
        //public ActionResult Ticket(int id)
        //{
        //    VoyageViewModel voyage = _service.GetVoyage(id);

        //    return View(voyage);
        //}
    }
}