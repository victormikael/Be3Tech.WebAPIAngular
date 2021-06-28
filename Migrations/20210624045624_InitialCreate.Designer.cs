﻿// <auto-generated />
using System;
using Be3Tech.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Be3Tech.WebAPI.Migrations
{
    [DbContext(typeof(PacienteContext))]
    [Migration("20210624045624_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Be3Tech.WebAPI.Models.Paciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<int>("RG")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.Property<string>("carteira")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("carteiraValidade")
                        .HasColumnType("datetime2");

                    b.Property<int>("celular")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("convenio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("genero")
                        .HasColumnType("bit");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prontuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefone")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("ufRG")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("id");

                    b.ToTable("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
