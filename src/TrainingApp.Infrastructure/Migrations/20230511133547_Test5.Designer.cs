﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingApp.Infrastructure;

#nullable disable

namespace TrainingApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511133547_Test5")]
    partial class Test5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TrainingApp.Application.Entities.Excercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ExcersiceType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBuiltIn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Excercises", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd51ee8e-12df-476b-a505-69e7c2dd9137"),
                            ExcersiceType = 0,
                            IsBuiltIn = true,
                            Name = "Pullups"
                        },
                        new
                        {
                            Id = new Guid("90a1197b-84df-488e-b76a-25bc08aaa9e4"),
                            ExcersiceType = 0,
                            IsBuiltIn = true,
                            Name = "Ab curl"
                        },
                        new
                        {
                            Id = new Guid("8cf5eb28-6064-4c10-a8ab-3968de781af4"),
                            ExcersiceType = 1,
                            IsBuiltIn = false,
                            Name = "Custom 1"
                        });
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Routine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routines", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("60967842-ffae-47d9-814a-7f76e4b55e86"),
                            Name = "Abs"
                        },
                        new
                        {
                            Id = new Guid("ef23aec6-5eb3-4b58-8109-dffa8606c112"),
                            Name = "Pull"
                        });
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.RoutineDates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoutineId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineDates", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.RoutineExcersices", b =>
                {
                    b.Property<Guid>("RoutineId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExcerciseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoutineId", "ExcerciseId");

                    b.HasIndex("ExcerciseId");

                    b.ToTable("RoutineExcercises", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Measure")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WorkoutExcerciseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutExcerciseId");

                    b.ToTable("Sets", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Workouts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b8bd380-9692-4b2b-a758-7bd1d4d4f839"),
                            Date = new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            Name = "Abs"
                        },
                        new
                        {
                            Id = new Guid("6d291289-14d3-47f5-8511-d24616f7be20"),
                            Date = new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            Name = "Pull"
                        },
                        new
                        {
                            Id = new Guid("0916f193-47fa-43cf-9952-9975a207938c"),
                            Date = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = true,
                            Name = "Abs"
                        });
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.WorkoutExcersices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExcerciseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExcercises", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.RoutineDates", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Routine", "Routine")
                        .WithMany("Dates")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Routine");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.RoutineExcersices", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Excercise", "Excercise")
                        .WithMany("RoutineExcersices")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingApp.Application.Entities.Routine", "Routine")
                        .WithMany("RoutineExcersices")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("Routine");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Set", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.WorkoutExcersices", "WorkoutExcercises")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutExcercises");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.WorkoutExcersices", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Excercise", "Excercise")
                        .WithMany("WorkoutExcersices")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingApp.Application.Entities.Workout", "Workout")
                        .WithMany("WorkoutExcersices")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Excercise", b =>
                {
                    b.Navigation("RoutineExcersices");

                    b.Navigation("WorkoutExcersices");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Routine", b =>
                {
                    b.Navigation("Dates");

                    b.Navigation("RoutineExcersices");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout", b =>
                {
                    b.Navigation("WorkoutExcersices");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.WorkoutExcersices", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}