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
    public class OrdersController : ApiController
    {
        Service _service = new Service();

        public string Get(int id)
        {
            var userName = User.Identity.Name;
            var  result = _service.NewOrder(id, userName);
          
            
            return result.ToString();
        }
        //[HttpPost]
        //public void Post([FromBody]int voyageId, int userId)
        //{
        //    int result=0;
        //    if (ModelState.IsValid)
        //       result= _service.NewOrder(voyageId);

        //   // return result.ToString();
        //}

        public void Put(int id)
        {
            if (ModelState.IsValid)
                _service.UpdateOrder(id, "reserved");
        }
    }
}
