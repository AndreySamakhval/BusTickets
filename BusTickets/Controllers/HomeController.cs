using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace BusTickets.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        IService _service;
        public HomeController(IService Service)
        {
            _service = Service;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tickets()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SearchVoyage(SearchVoyageViewModel voyage)
        {

            return Json(_service.SearchVoyages(voyage));
        }




        public void Init()
        {
            _service.InitDB();
        }
    }
}