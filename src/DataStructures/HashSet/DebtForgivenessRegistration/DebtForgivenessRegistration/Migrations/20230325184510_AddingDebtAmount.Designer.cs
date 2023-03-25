﻿// <auto-generated />
using System;
using DebtForgivenessRegistration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DebtForgivenessRegistration.Migrations
{
    [DbContext(typeof(RegistrarDbContext))]
    [Migration("20230325184510_AddingDebtAmount")]
    partial class AddingDebtAmount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("DebtForgivenessRegistration.Features.Customers.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgeOfDebt")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DebtAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SocialSecurityNumber")
                        .IsUnique();

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
