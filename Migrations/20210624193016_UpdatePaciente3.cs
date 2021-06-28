using Microsoft.EntityFrameworkCore.Migrations;

namespace Be3Tech.WebAPI.Migrations
{
    public partial class UpdatePaciente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ufRG",
                table: "Pacientes",
                newName: "UfRG");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Pacientes",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "sobrenome",
                table: "Pacientes",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "prontuario",
                table: "Pacientes",
                newName: "Prontuario");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "Pacientes",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Pacientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dataNascimento",
                table: "Pacientes",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "convenio",
                table: "Pacientes",
                newName: "Convenio");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "Pacientes",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "carteiraValidade",
                table: "Pacientes",
                newName: "CarteiraValidade");

            migrationBuilder.RenameColumn(
                name: "carteira",
                table: "Pacientes",
                newName: "Carteira");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pacientes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UfRG",
                table: "Pacientes",
                newName: "ufRG");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Pacientes",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Pacientes",
                newName: "sobrenome");

            migrationBuilder.RenameColumn(
                name: "Prontuario",
                table: "Pacientes",
                newName: "prontuario");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pacientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Pacientes",
                newName: "genero");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pacientes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Pacientes",
                newName: "dataNascimento");

            migrationBuilder.RenameColumn(
                name: "Convenio",
                table: "Pacientes",
                newName: "convenio");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Pacientes",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "CarteiraValidade",
                table: "Pacientes",
                newName: "carteiraValidade");

            migrationBuilder.RenameColumn(
                name: "Carteira",
                table: "Pacientes",
                newName: "carteira");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacientes",
                newName: "id");
        }
    }
}
