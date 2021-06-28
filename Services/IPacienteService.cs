using System.Collections.Generic;
using System.Threading.Tasks;
using Be3Tech.WebAPI.Models;

namespace Be3Tech.WebAPI.Services
{
    public interface IPacienteService
    {
        Task<bool> Create(Paciente paciente);
        IEnumerable<Paciente> GetByName(string name);
        Paciente GetById(int id);
        Paciente GetByCPF(string CPF);
        IEnumerable<Paciente> GetAll();
        Task<bool> Update(Paciente paciente);
    }
}