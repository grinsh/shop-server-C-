using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace shopServer.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        public IEnumerable<string> Get() { return new string[] { "value1", "value2" };}
        public List<OrderDTO> GetOrdersByUserId(int id) { return  OrderManager.GetOrdersByUserId(id);}

        public void Post([FromBody]string value) {}

        public void Put(int id, [FromBody]string value) { }

        // DELETE: api/Orders/5
        public void Delete(int id){ }
    }
}
