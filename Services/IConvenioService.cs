using System.Collections.Generic;
using Be3Tech.WebAPI.Models;

namespace Be3Tech.WebAPI.Services
{
    public interface IConvenioService
    {
        IEnumerable<Convenio> GetAllConvenio();
    }
}