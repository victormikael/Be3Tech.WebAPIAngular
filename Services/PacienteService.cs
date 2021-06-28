using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Be3Tech.WebAPI.Data;
using Be3Tech.WebAPI.Models;

namespace Be3Tech.WebAPI.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly PacienteContext _context;

        public PacienteService(PacienteContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            var create = await _context.SaveChangesAsync();

            return create == 1;
        }

        public IEnumerable<Paciente> GetAll()
        {
            var getAll = _context.Pacientes.ToList();

            return getAll;
        }

        public Paciente GetByCPF(string CPF)
        {
            var getByCPF = _context.Pacientes.Where(x => x.CPF == CPF).FirstOrDefault();

            return getByCPF;
        }

        public Paciente GetById(int id)
        {
            var getById = _context.Pacientes.Find(id);

            return getById;
        }

        public IEnumerable<Paciente> GetByName(string name)
        {
            var getByName = _context.Pacientes.Where(x => x.Nome.Contains(name));

            return getByName;
        }

        public async Task<bool> Update(Paciente paciente)
        {
            var _paciente = _context.Pacientes.Find(paciente.Id);
            
            _context.Pacientes.Update(_paciente).CurrentValues.SetValues(paciente);
            var update = await _context.SaveChangesAsync();

            return update == 1;
        }
    }
}