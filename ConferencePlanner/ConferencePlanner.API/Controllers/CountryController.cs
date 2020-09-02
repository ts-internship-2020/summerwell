using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
