using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Be3Tech.WebAPI.Models;
using Be3Tech.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Be3Tech.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioService _service;
        private readonly IMemoryCache _memoryCache;
        private const string CONVENIO_KEY = "Convenios";

        public ConvenioController(IConvenioService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Convenio>> GetAllConvenio()
        {
            if(_memoryCache.TryGetValue(CONVENIO_KEY, out IEnumerable<Convenio> getAllConvenio))
            {
                return Ok(getAllConvenio);
            }
            
            getAllConvenio = _service.GetAllConvenio();

            if(!getAllConvenio.Any())
            {
                return NotFound();
            }

            // Configurações de cache
            MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                // Horas de permanência do cache
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
            };
            
            // Adicionando cache
            _memoryCache.Set(CONVENIO_KEY, getAllConvenio, memoryCacheEntryOptions);
            
            return Ok(getAllConvenio);
        }
    }
}