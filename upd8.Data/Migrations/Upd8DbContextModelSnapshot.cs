﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using upd8.Data.context;

#nullable disable

namespace upd8.Data.Migrations
{
    [DbContext(typeof(Upd8DbContext))]
    partial class Upd8DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("upd8.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
