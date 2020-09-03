using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ILogger<ParticipantController> _logger;
        private readonly IParticipantRepository _participantRepository;
        public ParticipantController(ILogger<ParticipantController> logger, IParticipantRepository participantRepository)
        {
            _logger = logger;
            _participantRepository = participantRepository;
        }
        [HttpPost]
        [Route("Participant/AddParticipant")]
        public IActionResult AddParticipant([FromBody] ConferenceAudienceModel obj) 
        {
            _participantRepository.AddParticipant(obj);
            return Ok();
        }
        [HttpPost]
        [Route("Participant/UpdateParticipant")]
        public IActionResult UpdateParticipant([FromBody] ConferenceAudienceModel obj)
        {
            int status = _participantRepository.UpdateParticipant(obj);
            if (status != 0)
                return Ok();
            else
                return NotFound();
        }
        [HttpPost]
        [Route("Participant/UpdateParticipantToJoin")]
        public IActionResult UpdateParticipantToJoin([FromBody] ConferenceAudienceModel obj)
        {
            int status = _participantRepository.UpdateParticipantToJoin(obj);
            if (status != 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
