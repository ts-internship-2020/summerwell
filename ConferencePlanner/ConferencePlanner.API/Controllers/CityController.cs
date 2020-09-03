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
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly IDictionaryCityRepository _cityRepository;
        public CityController(ILogger<CityController> logger, IDictionaryCityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        [HttpPost]
        [Route("DictionaryCity/ConferenceId")]
        public IActionResult GetCity([FromBody]int conferenceId)
        {
            DictionaryCityModel city = _cityRepository.GetCity(conferenceId);
            return Ok(city);
        }

        [HttpPost]
        [Route("DictionaryCity")]
        public IActionResult GetCity()
        {
            List<DictionaryCityModel> cities = _cityRepository.GetCity();
            return Ok(cities);
        }

        [HttpPost]
        [Route("DictionaryCity/AddCity")]
        public IActionResult AddCity([FromBody] string Code, [FromBody] string Name, [FromBody] string county)
        {
            _cityRepository.AddCity(Code,Name,county);
            return Ok();
        }
        [HttpDelete]
        [Route("DictionaryCity/CityDelete")]
        public IActionResult DeleteCity(int CityId, bool IsRemote)
        {
            _cityRepository.DeleteCity(CityId, IsRemote);
            return Ok();
        }


        [HttpPut]
        [Route("DictionaryCity/EditCity")]
        public IActionResult EditCity(string Code, string Name, int CityId)
        {
            _cityRepository.EditCity(Code, Name, CityId);
            return Ok();
        }
    }
}
