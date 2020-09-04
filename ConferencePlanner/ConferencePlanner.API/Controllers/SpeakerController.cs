using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model.FromBodyModels;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly ILogger<SpeakerController> _logger;
        private readonly IGetSpeakerDetail _speakerrepository;
        public SpeakerController(ILogger<SpeakerController> logger, IGetSpeakerDetail speakerrepository)
        {
            _logger = logger;
            _speakerrepository = speakerrepository;
        }
        [HttpPost]
        [Route("Speaker/AddSpeaker")]
        public IActionResult AddSpeaker([FromBody] AddSpeaker obj)
        {
            _speakerrepository.AddSpeaker(obj.Email,obj.Name,obj.Nationality);
            return Ok();
        }
        [HttpPost]
        [Route("Speaker/EditSpeaker")]
        public IActionResult EditSpeaker([FromBody] EditSpeaker obj)
        {
            _speakerrepository.EditSpeaker(obj.Email,obj.Name,obj.Id,obj.Nationality);
            return Ok();
        }
        [HttpDelete]
        [Route("Speaker/DeleteSpeaker")]
        public IActionResult DeleteSpeaker([FromBody]int TypeId)
        {
            _speakerrepository.DeleteSpeaker(TypeId);
            return Ok();
        }
        [HttpGet]
        [Route("Speaker/GetSpeakers")]
        public IActionResult GetSpeakers()
        {
            var result = _speakerrepository.GetSpeakers();
            return Ok(result);
        }
    }
}
