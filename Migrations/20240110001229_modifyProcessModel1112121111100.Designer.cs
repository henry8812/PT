﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PTSeleccion.Backend.Models;

#nullable disable

namespace PTSeleccion.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240110001229_modifyProcessModel1112121111100")]
    partial class modifyProcessModel1112121111100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<int?>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerId");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationId"), 1L, 1);

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("EvaluationId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("TestId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.JobApplication", b =>
                {
                    b.Property<int>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobApplicationId"), 1L, 1);

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("ProcessId");

                    b.ToTable("JobApplication");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.JobOffer", b =>
                {
                    b.Property<int>("JobOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobOfferId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobOfferId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptionId"), 1L, 1);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Process", b =>
                {
                    b.Property<int>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcessId"), 1L, 1);

                    b.HasKey("ProcessId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int?>("TestTypeTypeId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("TestId");

                    b.HasIndex("TestTypeTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"), 1L, 1);

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<int>("TestTypeId")
                        .HasColumnType("int");

                    b.HasKey("TestId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("TestTypeId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.TestType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.HasKey("TypeId");

                    b.ToTable("TestTypes");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Answer", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.Evaluation", null)
                        .WithMany("Answers")
                        .HasForeignKey("EvaluationId");

                    b.HasOne("PTSeleccion.Backend.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Evaluation", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTSeleccion.Backend.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.JobApplication", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.JobOffer", "JobOffer")
                        .WithMany("jobApplications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTSeleccion.Backend.Models.Process", "Process")
                        .WithMany("JobApplications")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Option", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.Answer", null)
                        .WithMany("Options")
                        .HasForeignKey("AnswerId");

                    b.HasOne("PTSeleccion.Backend.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Question", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTSeleccion.Backend.Models.TestType", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestTypeTypeId");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Test", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.JobOffer", "JobOffer")
                        .WithMany("Tests")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTSeleccion.Backend.Models.TestType", "TestType")
                        .WithMany("Test")
                        .HasForeignKey("TestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("TestType");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Answer", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Evaluation", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.JobOffer", b =>
                {
                    b.Navigation("Tests");

                    b.Navigation("jobApplications");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Process", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("PTSeleccion.Backend.Models.TestType", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Test");
                });
#pragma warning restore 612, 618
        }
    }
}
