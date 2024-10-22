using CodeFirstApi.Data;
using CodeFirstApi.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public ApiController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = db.Events.Include(q => q.EventType);
            return Ok(events);
        }

        [HttpGet("EventTypes")]
        public IActionResult GetEventsTypes()
        {
            var eventTypes = db.EventType;
            return Ok(eventTypes);
        }

        [HttpPost]
        public IActionResult AddEvents(EventDTO ev)
        {
            if (ev != null)
            {
                Event newEvent = new Event()
                {
                    NoOfGuests = ev.NoOfGuests,
                    CustomerName = ev.CustomerName,
                    Data = ev.Data,
                    EventTypeId = ev.EventTypeId
                };

                var addedEvent = db.Events.Add(newEvent);
                db.SaveChanges();
                return Ok(addedEvent.Entity);
            }
            else
            {
                return BadRequest("INVALID DATA");
            }
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEvent(int eventId)
        {
            var eventItem = db.Events.Include(q => q.EventType).SingleOrDefault(j => j.Id == eventId);
            return Ok(eventItem);
        }

        [HttpPut]

        public IActionResult EditEvent(EventDTO ev)
        {
            if (ev != null)
            {
                var Event = db.Events.Find(ev.Id);
                if (Event != null)
                {
                    Event.NoOfGuests = ev.NoOfGuests;
                    Event.CustomerName = ev.CustomerName;
                    Event.Data = ev.Data;
                    Event.EventTypeId = ev.EventTypeId;
                    var editedEvent = db.Events.Add(Event);
                    db.SaveChanges();
                    return Ok(editedEvent.Entity);
                }
                else
                {
                    return BadRequest("Event NOt Found");
                }
            }
            else
            {
                return BadRequest("INVALID DATA");
            }
        }

        [HttpDelete]

        public IActionResult DeletedEvent(EventDTO ev)
        {
            if (ev != null)
            {
                var Event = db.Events.Find(ev.Id);
                if (Event != null)
                {
                    var deletedEvent = db.Events.Remove(Event);
                    db.SaveChanges();
                    return Ok(deletedEvent.Entity);
                }
                else
                {
                    return BadRequest("Event Not Found");
                }
            }
            else
            {
                return BadRequest("INVALID DATA");
            }
        }
        [HttpGet("Search/{q}")]
        public IActionResult SearchEvent(string q)
        {
            if (q != null)
            {

                //var Event = db.Events.Include(t => t.EventType).Where(t => t.CustomerName == q || t.EventType.Type == q);
                //if (Event != null) ;

                var Event = db.Events.Include(t => t.EventType).Where(t => t.CustomerName.Contains(q) || 
                t.EventType.Type.Contains(q));
                if(Event != null){
                 
                    return Ok(Event);
                }
                else
                {
                    return BadRequest("Event NOt Found");
                }
            }
            else
            {
                return BadRequest("INVALID DATA");
            }
        }



    }
}
