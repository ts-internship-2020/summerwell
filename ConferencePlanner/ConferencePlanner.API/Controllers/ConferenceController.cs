using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model.FromBodyModels;
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
        public IActionResult GetConferenceDetail([FromBody] StartEndDate startEndDate)
        {
            List<ConferenceDetailModel> conferencesDetails = _conferenceRepository.GetConferenceDetail(startEndDate.startDate, startEndDate.endDate);
            return Ok(conferencesDetails);
        }

        [HttpGet]
        [Route("Conference/ConferenceDetail")]
        public IActionResult GetConferenceDetail()
        {
            List<ConferenceDetailModel> conferencesDetails = _conferenceRepository.GetConferenceDetail();
            return Ok(conferencesDetails);
        }
        [HttpPost]
        [Route("Conference/GetConferenceAudience")]

        public IActionResult GetConferenceAudience([FromBody] string email)
        {
            List<ConferenceAudienceModel> conferencesAudience = _conferenceRepository.GetConferenceAudience(email);
            return Ok(conferencesAudience);
        }
        [HttpPost]
        [Route("Conference/ConferenceDetailForHost")]
        public IActionResult GetConferenceDetailForHost([FromBody] string email)
        {
            List<ConferenceDetailModel> conferencesDetails = _conferenceRepository.GetConferenceDetailForHost(email);
            return Ok(conferencesDetails);
        }
        [HttpPut]
        [Route("Conference/EditCountry")]
        public IActionResult EditCountry(int Id, string Code,string Name)
        {
            _conferenceRepository.EditCountry(Id, Code, Name);
            return Ok();
        }
        [HttpDelete]
        [Route("Conference/DeleteType")]
        public IActionResult DeleteType(int TypeId, bool IsRemote)
        {
            _conferenceRepository.DeleteType(TypeId, IsRemote);
            return Ok();
        }

        [HttpPost]
        [Route("DictionaryCountry/AddCountry")]
        public IActionResult AddCountry(string Code, string Name)
        {
            _conferenceRepository.AddCountry(Code, Name);
            return Ok();
        }
       
        [HttpPut]
        [Route("Conference/AddCategory")]
        public IActionResult AddCategory(string Name)
        {
            _conferenceRepository.AddCategory(Name);
            return Ok();
        }
        [HttpPost]
        [Route("Conference/GetAttendedConferencesFirst")]
        public IActionResult GetAttendedConferencesFirst([FromBody] GetAttendedConferencesFirstModel model)
        {
            List<ConferenceAudienceModel> conferencesAudience = _conferenceRepository.GetConferenceAudience(model.Email);
            List<ConferenceDetailAttendFirstModel> attendedConferencesFirst = _conferenceRepository.GetAttendedConferencesFirst(conferencesAudience, model.StartDate, model.EndDate);
            return Ok(attendedConferencesFirst);

        }
    }
}
