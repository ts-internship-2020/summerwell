using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Model.FromBodyModels;
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

        [HttpGet]
        [Route("DictionaryCity")]
        public IActionResult GetCity()
        {
            List<DictionaryCityModel> cities = _cityRepository.GetCity();
            return Ok(cities);
        }

        [HttpPost]
        [Route("DictionaryCity/AddCity")]
        public IActionResult AddCity([FromBody] AddCity obj)
        {
            _cityRepository.AddCity(obj.Code, obj.Name, obj.county);
            return Ok();
        }

        [HttpDelete]
        [Route("DictionaryCity/CityDelete")]
        public IActionResult DeleteCity([FromBody]DeleteType obj)
        {
            _cityRepository.DeleteCity(obj.Id, obj.isRemote);
            return Ok();
        }
        [HttpPost]
        [Route("DictionaryCity/EditCity")]
        public IActionResult Edit([FromBody] EditCity obj)
        {
            _cityRepository.EditCity(obj.Code, obj.Name, obj.Id);
            return Ok();
        }
    }
}
