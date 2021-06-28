using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Be3Tech.WebAPI.Models;
using Be3Tech.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Be3Tech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(Paciente paciente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(paciente.CPF != null)
            {
                var consulta = _service.GetByCPF(paciente.CPF);

                if(consulta != null)
                {
                    return BadRequest();
                }
            }

            bool create = await _service.Create(paciente);

            if(!create)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(Create), new { id = paciente.Id });
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Paciente> GetById(int id)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }

            var getById = _service.GetById(id);

            if(getById == null)
            {
                return NotFound();
            }

            return Ok(getById);
        }

        [HttpGet("search/{name}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Paciente>> GetByName(string name)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var getByName = _service.GetByName(name);

            if(!getByName.Any())
            {
                return NotFound();
            }

            return Ok(getByName);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Paciente>> GetAll()
        {
            var getAll = _service.GetAll();

            if(!getAll.Any())
            {
                return NotFound();
            }

            return Ok(getAll);
        }

        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(Paciente paciente)
        {
            if(!ModelState.IsValid || paciente.Id <= 0)
            {
                return BadRequest();
            }

            var _paciente = _service.GetById(paciente.Id);

            if(_paciente == null)
            {
                NotFound();
            }

            if(paciente.CPF != _paciente.CPF)
            {
                var consulta = _service.GetByCPF(paciente.CPF);

                if(consulta != null)
                {
                    return BadRequest();
                }
            }

            bool update = await _service.Update(paciente);
            
            if(!update)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(_paciente);
        }
    }
}