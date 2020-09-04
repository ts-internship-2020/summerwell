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
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IDictionaryCountryRepository _countryRepository;
        public CountryController(ILogger<CountryController> logger, IDictionaryCountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }
        
        [HttpPost]
        [Route("AddCountry")]
        public IActionResult AddCountry([FromBody] AddCountry obj)
        {
            _countryRepository.AddCountry(obj.Code, obj.Name);
            return Ok();
        }
        
        
        [HttpGet]
        [Route("GetDictionaryCountry")]
        public IActionResult GetDictionaryCountry()
        {
            List<DictionaryCountryModel> countries = _countryRepository.GetDictionaryCountry();
            return Ok(countries);
        }

        [HttpPost]
        [Route("DeleteCountry")]
        public IActionResult DeleteCountry([FromBody] DeleteType obj)
        {
            _countryRepository.DeleteCountry(obj.Id, obj.isRemote);
            return Ok();
        }
        [HttpPost]
        [Route("EditCountry")]
        public IActionResult EditCountry([FromBody] EditCountry obj)
        {
            _countryRepository.EditCountry(obj.Id, obj.Code, obj.Name);
            return Ok();
        }
    }
}
