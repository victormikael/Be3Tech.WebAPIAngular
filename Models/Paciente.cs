using System;
using System.ComponentModel.DataAnnotations;

namespace Be3Tech.WebAPI.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Prontuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [MaxLength(1)]
        public string Genero { get; set; }
        [MaxLength(14)]
        public string CPF { get; set; }
        [MaxLength(12)]
        public string RG { get; set; }
        [MaxLength(2)]
        public string UfRG { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(13)]
        public string Celular { get; set; }
        [MaxLength(12)]
        public string Telefone { get; set; }
        public string Convenio { get; set; }
        public string Carteira { get; set; }
        public DateTime? CarteiraValidade { get; set; }
    }
}