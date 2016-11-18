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
        // GET: api/StopInfo
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/StopInfo/5
        public IEnumerable<StopInfoViewModel> Get(int id)
        {
            return _service.GetStopInfo(id);
        }

        //// POST: api/StopInfo
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/StopInfo/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/StopInfo/5
        //public void Delete(int id)
        //{
        //}
    }
}
