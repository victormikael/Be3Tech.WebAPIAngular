using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Be3Tech.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prontuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    genero = table.Column<bool>(type: "bit", nullable: false),
                    CPF = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    RG = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    ufRG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    celular = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    telefone = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carteira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carteiraValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
