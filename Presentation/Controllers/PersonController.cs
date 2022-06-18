using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{

    [Route("api/v1/[controller]")]
    public class PersonController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("all-people")]
        public async Task<IActionResult> getAllPeople([FromQuery]int pageNo = 0, [FromQuery] int pageSize = 50, CancellationToken cancellationToken = default)
        {
            var response = await _serviceManager.PersonService.GetAllPeopleAsync(pageNo, pageSize, cancellationToken);
            return Ok(response);
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> registerPerson([FromBody] PersonForCreatingDto personDto, CancellationToken cancellationToken = default)
        {
            var response = await this._serviceManager.PersonService.registerPerson(personDto, cancellationToken);
            return Ok(response);
        }
    }
}
