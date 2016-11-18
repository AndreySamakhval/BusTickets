using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
//using System.Web.Mvc;
using ViewModels;

namespace BusTickets.Controllers.Api
{
    public class StopController : ApiController
    {
        Service _service = new Service();
        // GET: api/Stop
        public IEnumerable<StopViewModel> Get()
        {
            return _service.GetStops();

                
        }

        // GET: api/Stop
        public IEnumerable<StopViewModel> Get(string Name)
        {
            
            return _service.GetStops(Name);
        }

        // GET: api/Stop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stop
        public void Post(StopViewModel stop)
        {
            if(ModelState.IsValid)
            _service.AddStop(stop);
        }

        // PUT: api/Stop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stop/5
        public void Delete(int id)
        {
        }
    }
}
