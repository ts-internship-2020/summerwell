using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
