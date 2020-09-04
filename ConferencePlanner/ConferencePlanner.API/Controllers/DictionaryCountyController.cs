using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Model.FromBodyModels;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api.Controllers
{
    public class DictionaryCountyController : Controller
    {
        private readonly ILogger<DictionaryCountyController> _logger;
        private readonly IDictionaryCountyRepository _countyRepository;
        public DictionaryCountyController(ILogger<DictionaryCountyController> logger, IDictionaryCountyRepository countyRepository)
        {
            _logger = logger;
            _countyRepository = countyRepository;
        }

        [HttpGet]
        [Route("DictionaryCounty")]
        public IActionResult GetDictionaryCounty()
        {
            List<DictionaryCountyModel> county = _countyRepository.GetDictionaryCounty();
            return Ok(county);
        }
        [HttpGet]
        [Route("GetDictionaryCounty")]
        public IActionResult GetDictionaryCounty(int obj)
        {
            DictionaryCountyModel countries = _countyRepository.GetCounty(obj);
            return Ok(countries);
        }

        [HttpPost]
        [Route("DictionaryCounty/AddCounty")]
        public IActionResult AddCounty([FromBody] AddCounty obj)
        {
            _countyRepository.AddCounty(obj.Code, obj.Name, obj.country);
            return Ok();
        }

        [HttpPost]
        [Route("DictionaryCounty/EditCounty")]
        public IActionResult EditCounty([FromBody] EditCounty obj)
        {
            _countyRepository.EditCounty(obj.Code, obj.Name, obj.Id);
            return Ok();
        }

        [HttpDelete]
        [Route("DictionaryCounty/DeleteCounty")]
        public IActionResult DeleteCounty([FromBody] int obj)
        {
            bool x = _countyRepository.DeleteCounty(obj);
            if (x == true)
                return Ok();
            else return NoContent();
        }
    }
}
