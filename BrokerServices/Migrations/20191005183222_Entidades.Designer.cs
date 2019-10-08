﻿// <auto-generated />
using BrokerServices.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BrokerServices.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20191005183222_Entidades")]
    partial class Entidades
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
#pragma warning restore 612, 618
        }
    }
}
