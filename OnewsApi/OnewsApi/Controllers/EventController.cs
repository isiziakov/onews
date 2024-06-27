using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnewsApi.Models;
using OnewsApi.Operations;

namespace OnewsApi.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("api/Event/GetEvents")]
        public IActionResult GetEvents()
        {
            DbOperations db = new DbOperations();
            return Ok(JsonConvert.SerializeObject(db.GetEvents()));
        }

        [HttpPost]
        [Route("api/Event/GetEvent")]
        public IActionResult GetEvent([FromBody] int id)
        {
            DbOperations db = new DbOperations();
            return Ok(JsonConvert.SerializeObject(db.GetEvent(id)));
        }

        [HttpPost]
        [Route("api/Event/GetEventStrings")]
        public IActionResult GetEventStrings([FromBody] int id)
        {
            DbOperations db = new DbOperations();
            return Ok(JsonConvert.SerializeObject(db.GetEventStrings(id)));
        }

        [HttpPost]
        [Route("api/Event/CheckReg")]
        public IActionResult CheckReg([FromBody] EventReg reg)
        {
            DbOperations db = new DbOperations();
            return Ok(db.CheckEventReg(reg));
        }

        [HttpPost]
        [Route("api/Event/MakeReg")]
        public IActionResult MakeReg([FromBody] EventReg reg)
        {
            DbOperations db = new DbOperations();
            db.MakeReg(reg);
            return Ok();
        }

        [HttpPost]
        [Route("api/Event/RemoveReg")]
        public IActionResult RemoveReg([FromBody] EventReg reg)
        {
            DbOperations db = new DbOperations();
            db.RemoveReg(reg);
            return Ok();
        }

        [HttpPost]
        [Route("api/Event/GetAllReg")]
        public IActionResult GetAllReg([FromBody] int id)
        {
            DbOperations db = new DbOperations();
            return Ok(db.GetAllReg(id));
        }

        [HttpPost]
        [Route("api/Event/GetEventsForUser")]
        public IActionResult GetEventsForUser([FromBody] int id)
        {
            DbOperations db = new DbOperations();
            return Ok(db.GetEventsForUser(id));
        }

        [HttpPost]
        [Route("api/Event/GetPastEventsForUser")]
        public IActionResult GetPastEventsForUser([FromBody] int id)
        {
            DbOperations db = new DbOperations();
            return Ok(db.GetPastEventsForUser(id));
        }
    }
}
