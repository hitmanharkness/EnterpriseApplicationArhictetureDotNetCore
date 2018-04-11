using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlertsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AlertsController : Controller
    {
        // GET api/values
        [HttpGet]
        public object Get()
        {
            return new
            {
                Id = 123,
                event_code = 1,
                client_id = 425758,
            };
        }
    
        

        // GET api/alerts/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return 123;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
