﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shopServer.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
 

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/values/SayHello/{fname}/{lname}")]
        public string SayHello(string fname, string lname)
        {
            return "Hello to " + fname + " " + lname;
        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
