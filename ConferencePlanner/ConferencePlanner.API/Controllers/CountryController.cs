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
        public IActionResult AddCountry(string Code, string Name)
        {
            _countryRepository.AddCountry(Code, Name);
            return Ok();
        }
        
        
        [HttpGet]
        [Route("GetDictionaryCountry")]
        public IActionResult GetDictionaryCountry()
        {
            List<DictionaryCountryModel> countries = _countryRepository.GetDictionaryCountry();
            return Ok(countries);
        }
        

    }
}
