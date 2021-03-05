﻿// <auto-generated />
using System;
using DeLosRiosCredit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeLosRiosCredit.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeLosRiosCredit.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<float>("DTI")
                        .HasColumnType("real");

                    b.Property<int?>("FICO")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IncomeAnnual")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("DeLosRiosCredit.Models.CreditApplication", b =>
                {
                    b.Property<int>("CreditApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("APR")
                        .HasColumnType("real");

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<float>("LoanAmount")
                        .HasColumnType("real");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TermMonths")
                        .HasColumnType("int");

                    b.HasKey("CreditApplicationId");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("StatusId");

                    b.ToTable("CreditApplications");
                });

            modelBuilder.Entity("DeLosRiosCredit.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("DeLosRiosCredit.Models.CreditApplication", b =>
                {
                    b.HasOne("DeLosRiosCredit.Models.Applicant", "Applicant")
                        .WithMany("CreditApplications")
                        .HasForeignKey("ApplicantId");

                    b.HasOne("DeLosRiosCredit.Models.Status", "Status")
                        .WithMany("CreditApplications")
                        .HasForeignKey("StatusId");

                    b.Navigation("Applicant");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DeLosRiosCredit.Models.Applicant", b =>
                {
                    b.Navigation("CreditApplications");
                });

            modelBuilder.Entity("DeLosRiosCredit.Models.Status", b =>
                {
                    b.Navigation("CreditApplications");
                });
#pragma warning restore 612, 618
        }
    }
}