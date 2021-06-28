using Microsoft.EntityFrameworkCore;
using Be3Tech.WebAPI.Models;

namespace Be3Tech.WebAPI.Data
{
    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> options)
            : base(options)
        {
        }
        
        public DbSet<Paciente> Pacientes { get; set; }
    }
}