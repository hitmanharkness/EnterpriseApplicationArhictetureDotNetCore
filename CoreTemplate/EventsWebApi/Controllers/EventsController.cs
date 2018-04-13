using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        // GET api/events
        [HttpGet]
        public List<Event> Get()
        {
            var events = new List<Event>();

            events.Add(new Event
            {
                Id = 123,
                event_code = 1,
                client_id = 41298,
            });
            events.Add(new Event
            {
                Id = 456,
                event_code = 2,
                client_id = 41298,
            });

            return events;
        }

        public class Event
        {
            public int Id;
            public int event_code;
            public int client_id;
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
