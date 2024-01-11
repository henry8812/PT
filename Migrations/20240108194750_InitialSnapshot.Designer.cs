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
    [Migration("20240108194750_InitialSnapshot")]
    partial class InitialSnapshot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("CandidateUserId")
                        .HasColumnType("int");

                    b.HasKey("ProcessId");

                    b.HasIndex("CandidateUserId");

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

            modelBuilder.Entity("PTSeleccion.Backend.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("PTSeleccion.Backend.Models.Process", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.User", "CandidateUser")
                        .WithMany()
                        .HasForeignKey("CandidateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CandidateUser");
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

            modelBuilder.Entity("PTSeleccion.Backend.Models.User", b =>
                {
                    b.HasOne("PTSeleccion.Backend.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
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

            modelBuilder.Entity("PTSeleccion.Backend.Models.Role", b =>
                {
                    b.Navigation("Users");
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
