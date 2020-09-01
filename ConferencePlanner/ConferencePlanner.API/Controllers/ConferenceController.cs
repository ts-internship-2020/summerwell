using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConferenceRepository _getConferenceRepository;

        public ConferenceController(ILogger<HomeController> logger, IConferenceRepository getConferenceRepository)
        {
            _logger = logger;
            _getConferenceRepository = getConferenceRepository;
        }

        [HttpGet]
       //[Route("{DemoName}")]
        public IActionResult GetConference([FromRoute] string conferenceName)
        {
            List<ConferenceModel> conferenceModels = _getConferenceRepository.GetConference();
            return Ok(conferenceModels);
        }
    }
}
