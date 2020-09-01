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
    public class ConferenceController : Controller
    {
        private readonly ILogger<ConferenceController> _logger;
        private readonly IConferenceRepository _conferenceRepository;
        public ConferenceController(ILogger<ConferenceController> logger, IConferenceRepository conferenceRepository)
        {
            _logger = logger;
            _conferenceRepository = conferenceRepository;
        }
        [HttpGet]
        [Route("Conference")]
        public IActionResult GetConferences()
        {
            List<ConferenceModel> conferences = _conferenceRepository.GetConference();
            return Ok(conferences);
        }
        [HttpPost]
        [Route("Conference/DataGridView")]
        public IActionResult GetConferenceDetail([FromBody] DateTime StartDate, [FromBody] DateTime EndDate)
        {
            List<ConferenceDetailModel> conferencesDetails = _conferenceRepository.GetConferenceDetail(StartDate, EndDate);
            return Ok(conferencesDetails);
        }
    }
}
