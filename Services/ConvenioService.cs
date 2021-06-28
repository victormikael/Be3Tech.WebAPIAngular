using System.Collections.Generic;
using Be3Tech.WebAPI.Models;
using Be3Tech.WebAPI.Data;
using System.Linq;

namespace Be3Tech.WebAPI.Services
{
    public class ConvenioService : IConvenioService
    {
        private readonly ConvenioContext _context;

        public ConvenioService(ConvenioContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Convenio> GetAllConvenio()
        {
            var getAllConvenio = _context.Convenios.ToList();

            return getAllConvenio;
        }
    }
}