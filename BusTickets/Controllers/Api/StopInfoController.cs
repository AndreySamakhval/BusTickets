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
    public class StopInfoController : ApiController
    {
        Service _service = new Service();
        
        // GET: api/StopInfo/5
        public IEnumerable<StopInfoViewModel> Get(int id)
        {
            return _service.GetStopInfo(id);
        }
       
    }
}
