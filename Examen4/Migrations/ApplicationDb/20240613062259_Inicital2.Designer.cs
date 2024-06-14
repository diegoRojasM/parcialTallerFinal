﻿// <auto-generated />
using System;
using Examen3.ServiceApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen3.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240613062259_Inicital2")]
    partial class Inicital2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen3.ServiceApp2.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreEquipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organizacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepresentanteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCreador")
                        .HasColumnType("int");

                    b.Property<string>("InformacionContacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCreador");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organizacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profesion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Equipo", b =>
                {
                    b.HasOne("Examen3.ServiceApp2.Participante", "Representante")
                        .WithMany()
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representante");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Evento", b =>
                {
                    b.HasOne("Examen3.ServiceApp2.Usuario", "Creador")
                        .WithMany("EventosCreados")
                        .HasForeignKey("IdCreador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creador");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Participante", b =>
                {
                    b.HasOne("Examen3.ServiceApp2.Equipo", null)
                        .WithMany("Miembros")
                        .HasForeignKey("EquipoId");

                    b.HasOne("Examen3.ServiceApp2.Evento", null)
                        .WithMany("Participantes")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Equipo", b =>
                {
                    b.Navigation("Miembros");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Evento", b =>
                {
                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("Examen3.ServiceApp2.Usuario", b =>
                {
                    b.Navigation("EventosCreados");
                });
#pragma warning restore 612, 618
        }
    }
}