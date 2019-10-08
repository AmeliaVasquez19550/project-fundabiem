﻿// <auto-generated />
using System;
using BrokerServices.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BrokerServices.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20191008140758_paisGuatemala")]
    partial class paisGuatemala
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EntityModelFundabien.entities.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nombre")
                        .IsRequired();

                    b.HasKey("AutorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Correo", b =>
                {
                    b.Property<double>("idCorreo");

                    b.Property<string>("correo");

                    b.Property<bool>("estaHabilitado");

                    b.Property<DateTime>("fechaRegistro");

                    b.Property<double?>("personaidPersona");

                    b.HasKey("idCorreo");

                    b.HasIndex("personaidPersona");

                    b.ToTable("Correos");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Departamento", b =>
                {
                    b.Property<double>("idDepartamento");

                    b.Property<double>("idPais");

                    b.Property<string>("nombre");

                    b.HasKey("idDepartamento");

                    b.HasIndex("idPais");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Direccion", b =>
                {
                    b.Property<double>("idDireccion");

                    b.Property<string>("descripcion");

                    b.Property<double>("idMunicipio");

                    b.HasKey("idDireccion");

                    b.HasIndex("idMunicipio");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Municipio", b =>
                {
                    b.Property<double>("idMunicipio");

                    b.Property<double>("idDepartamento");

                    b.Property<string>("nombre");

                    b.HasKey("idMunicipio");

                    b.HasIndex("idDepartamento");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Pais", b =>
                {
                    b.Property<double>("idPais");

                    b.Property<string>("nombre");

                    b.HasKey("idPais");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            idPais = 1.0,
                            nombre = "Guatemala"
                        });
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Persona", b =>
                {
                    b.Property<double>("idPersona");

                    b.Property<string>("escolaridad");

                    b.Property<DateTime>("fechaNacimiento");

                    b.Property<string>("grupoEtnico");

                    b.Property<double>("idDomicilio");

                    b.Property<double>("idResidencia");

                    b.Property<string>("primerApellido");

                    b.Property<string>("primerNombre");

                    b.Property<string>("religion");

                    b.Property<string>("segundoApellido");

                    b.Property<string>("segundoNombre");

                    b.Property<bool>("sexo");

                    b.HasKey("idPersona");

                    b.HasIndex("idDomicilio");

                    b.HasIndex("idResidencia");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Telefono", b =>
                {
                    b.Property<double>("idTelefono");

                    b.Property<bool>("estaHabilitado");

                    b.Property<DateTime>("fechaRegistro");

                    b.Property<double>("idPersona");

                    b.Property<string>("telefono");

                    b.HasKey("idTelefono");

                    b.HasIndex("idPersona");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Correo", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("personaidPersona");
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Departamento", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Pais", "pais")
                        .WithMany("departamentos")
                        .HasForeignKey("idPais")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Direccion", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Municipio", "municipio")
                        .WithMany("direcciones")
                        .HasForeignKey("idMunicipio")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Municipio", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Departamento")
                        .WithMany("municipios")
                        .HasForeignKey("idDepartamento")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Persona", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Direccion", "domicilio")
                        .WithMany()
                        .HasForeignKey("idDomicilio")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EntityModelFundabien.entities.Direccion", "residencia")
                        .WithMany()
                        .HasForeignKey("idResidencia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityModelFundabien.entities.Telefono", b =>
                {
                    b.HasOne("EntityModelFundabien.entities.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("idPersona")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
