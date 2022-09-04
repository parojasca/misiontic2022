﻿// <auto-generated />
using System;
using MascotaFeliz.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220904034446_segunda")]
    partial class segunda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Historia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("fechaInicial")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("duenoid")
                        .HasColumnType("int");

                    b.Property<string>("especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("historiaid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("veterinarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("duenoid");

                    b.HasIndex("historiaid");

                    b.HasIndex("veterinarioid");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.VisitaPyP", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Historiaid")
                        .HasColumnType("int");

                    b.Property<string>("estadoAnimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnType("datetime2");

                    b.Property<float>("frecuenciaCardiaca")
                        .HasColumnType("real");

                    b.Property<float>("frecuenciaRespiratoria")
                        .HasColumnType("real");

                    b.Property<int>("idVeterinario")
                        .HasColumnType("int");

                    b.Property<float>("peso")
                        .HasColumnType("real");

                    b.Property<string>("recomendaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("temperatura")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("Historiaid");

                    b.ToTable("VisitasPyP");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Dueno", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Dueno");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("MascotaFeliz.App.Dominio.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Mascota", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Dueno", "dueno")
                        .WithMany()
                        .HasForeignKey("duenoid");

                    b.HasOne("MascotaFeliz.App.Dominio.Historia", "historia")
                        .WithMany()
                        .HasForeignKey("historiaid");

                    b.HasOne("MascotaFeliz.App.Dominio.Veterinario", "veterinario")
                        .WithMany()
                        .HasForeignKey("veterinarioid");

                    b.Navigation("dueno");

                    b.Navigation("historia");

                    b.Navigation("veterinario");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.VisitaPyP", b =>
                {
                    b.HasOne("MascotaFeliz.App.Dominio.Historia", null)
                        .WithMany("VisitasPyP")
                        .HasForeignKey("Historiaid");
                });

            modelBuilder.Entity("MascotaFeliz.App.Dominio.Historia", b =>
                {
                    b.Navigation("VisitasPyP");
                });
#pragma warning restore 612, 618
        }
    }
}