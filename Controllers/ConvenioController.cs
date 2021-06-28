using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Be3Tech.WebAPI.Models;
using Be3Tech.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Be3Tech.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioService _service;

        public ConvenioController(IConvenioService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Convenio>> GetAllConvenio()
        {
            var getAllConvenio = _service.GetAllConvenio();

            if(!getAllConvenio.Any())
            {
                return NotFound();
            }
            
            return Ok(getAllConvenio);
        }
    }
}