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
    public class VoyageController : ApiController
    {
        Service _service = new Service();

        public IEnumerable<VoyageViewModel> Get(int DepId, int ArrId, string date)
        {

            return _service.SearchVoyages(new SearchVoyageViewModel {DepartureId=DepId, ArriveId=ArrId, Date=DateTime.Parse(date)});
        }

        //public void Post(SearchVoyageViewModel voyage)
        //{
        //    if (ModelState.IsValid)
        //        _service.SearchVoyages(voyage);
        //}
    }
}
