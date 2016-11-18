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
    public class OrderController : ApiController
    {
        Service _service = new Service();

        public string Get(int id)
        {
          var  result = _service.NewOrder(id);

            return result.ToString();
        }

        public void Post(int voyageId)
        {
            int result=0;
            if (ModelState.IsValid)
               result= _service.NewOrder(voyageId);

           // return result.ToString();
        }

        public void Put(int id, string status)
        {
            if (ModelState.IsValid)
                _service.UpdateOrder(id, status);
        }
    }
}
