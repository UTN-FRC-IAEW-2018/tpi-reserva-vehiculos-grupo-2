﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace tpapi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180627010722_ReservasMigration")]
    partial class ReservasMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<long>("DNI");

                    b.Property<int>("ExtId");

                    b.Property<DateTime>("FechaDevolucion");

                    b.Property<DateTime>("FechaRetiro");

                    b.Property<string>("LugarDevolucion");

                    b.Property<string>("LugarRetiro");

                    b.Property<decimal>("TotalReserva");

                    b.Property<int>("UserId");

                    b.Property<int>("VehiculoXCiudadId");

                    b.HasKey("Id");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("Apellido");

                    b.Property<long>("DNI");

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<string>("RefreshToken");

                    b.Property<DateTime>("TokenExpiration");

                    b.Property<string>("Username");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
