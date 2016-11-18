using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTickets.Controllers
{
    public class HomeController : Controller
    {
        Service _service = new Service();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tickets()
        {
            return View();
        }




        public void Init()
        {
            _service.InitDB();
        }
    }
}