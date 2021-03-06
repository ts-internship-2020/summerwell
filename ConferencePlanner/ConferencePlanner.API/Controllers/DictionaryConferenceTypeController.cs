﻿using System;
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
    public class DictionaryConferenceTypeController : Controller
    {
        private readonly ILogger<DictionaryConferenceTypeController> _logger;
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        public DictionaryConferenceTypeController(ILogger<DictionaryConferenceTypeController> logger, IConferenceTypeRepository conferenceTypeRepository)
        {
            _logger = logger;
            _conferenceTypeRepository = conferenceTypeRepository;
        }

        [HttpGet]
        [Route("DictionaryConferenceType")]
        public IActionResult GetConferenceType()
        {
            List<ConferenceTypeModel> conferencesTypes = _conferenceTypeRepository.GetConferenceType();
            return Ok(conferencesTypes);
        }

        [HttpPost]
        [Route("DictionaryConferenceType/AddType")]
        public IActionResult AddType([FromBody] AddType obj)
        {
            _conferenceTypeRepository.AddType(obj.Name, obj.isRemote);
            return Ok();
        }

        [HttpPost]
        [Route("DictionaryConferenceType/EditType")]
        public IActionResult EditType(EditType obj)
        {
            _conferenceTypeRepository.EditType(obj.id, obj.Name, obj.isRemote);
            return Ok();
        }
        [HttpDelete]
        [Route("DictionaryConferenceType/DeleteType")]
        public IActionResult DeleteType([FromBody] DeleteType obj)
        {
            _conferenceTypeRepository.DeleteType(obj.Id, obj.isRemote);
            return Ok();
        }

    }
}
