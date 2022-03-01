﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement21A2.Data;

namespace StudentManagement21A2.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20220124202308_finalna")]
    partial class finalna
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentManagement21A2.Models.All_Car", b =>
                {
                    b.Property<string>("Klasa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nr_rej")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rocznik")
                        .HasColumnType("int");

                    b.ToView("samochody_wszystkie");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.All_Cars_Rent", b =>
                {
                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nazwisko");

                    b.ToView("wypozyczenia_wszystkie");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Car", b =>
                {
                    b.Property<int>("Id_auta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Klasa")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rocznik")
                        .HasColumnType("int");

                    b.Property<string>("Silnik")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_auta");

                    b.HasIndex("Klasa");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Client", b =>
                {
                    b.Property<int>("Id_klienta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id_klienta");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.CopyCar", b =>
                {
                    b.Property<string>("Nr_rej")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("Id_auta")
                        .HasColumnType("int");

                    b.HasKey("Nr_rej");

                    b.HasIndex("Id_auta");

                    b.ToTable("CopyCars");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Prize", b =>
                {
                    b.Property<string>("Klasa")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Klasa");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Rent", b =>
                {
                    b.Property<int>("Id_wynajmu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_do")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_od")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_klienta")
                        .HasColumnType("int");

                    b.Property<string>("Nr_rej")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id_wynajmu");

                    b.HasIndex("Id_klienta");

                    b.HasIndex("Nr_rej");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("StudentManagement21A2.ViewModels.LoginViewModel", b =>
                {
                    b.Property<int>("Id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_user");

                    b.ToTable("LoginViewModel");
                });

            modelBuilder.Entity("StudentManagement21A2.ViewModels.RegisterViewModel", b =>
                {
                    b.Property<int>("Id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_user");

                    b.ToTable("RegisterViewModels");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Car", b =>
                {
                    b.HasOne("StudentManagement21A2.Models.Prize", "Prize")
                        .WithMany()
                        .HasForeignKey("Klasa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prize");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.CopyCar", b =>
                {
                    b.HasOne("StudentManagement21A2.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("Id_auta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("StudentManagement21A2.Models.Rent", b =>
                {
                    b.HasOne("StudentManagement21A2.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("Id_klienta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement21A2.Models.CopyCar", "CopyCar")
                        .WithMany()
                        .HasForeignKey("Nr_rej")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("CopyCar");
                });
#pragma warning restore 612, 618
        }
    }
}
