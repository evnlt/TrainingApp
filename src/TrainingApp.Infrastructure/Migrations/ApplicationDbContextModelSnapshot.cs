﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingApp.Infrastructure;

#nullable disable

namespace TrainingApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TrainingApp.Application.Entities.Metric", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float?>("FatPercentage")
                        .HasColumnType("REAL");

                    b.Property<float?>("MusclePercentage")
                        .HasColumnType("REAL");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Metrics", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Excercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<bool>("InUse")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBuiltIn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Excercise", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.Property<Guid>("WorkoutExcerciseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutExcerciseId");

                    b.ToTable("Sets", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkoutTemplateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutTemplateId");

                    b.ToTable("Workouts", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.WorkoutTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<bool>("InUse")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBuiltIn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WorkoutTemplates", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.WorkoutTemplates2Excercises", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExcerciseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WorkoutTemplateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("WorkoutTemplateId");

                    b.ToTable("WorkoutTemplates_Excercises", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workouts2Excersices", b =>
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

                    b.ToTable("Workout_Excercises", (string)null);
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Set", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Workout.Workouts2Excersices", "Workouts2Excercises")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workouts2Excercises");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workout", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Workout.WorkoutTemplate", "WorkoutTemplate")
                        .WithMany("Workouts")
                        .HasForeignKey("WorkoutTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutTemplate");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.WorkoutTemplates2Excercises", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Workout.Excercise", "Excercise")
                        .WithMany("WorkoutTemplates2Excercises")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingApp.Application.Entities.Workout.WorkoutTemplate", "WorkoutTemplate")
                        .WithMany("WorkoutTemplates2Excercises")
                        .HasForeignKey("WorkoutTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("WorkoutTemplate");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workouts2Excersices", b =>
                {
                    b.HasOne("TrainingApp.Application.Entities.Workout.Excercise", "Excercise")
                        .WithMany("Workouts2Excersices")
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingApp.Application.Entities.Workout.Workout", "Workout")
                        .WithMany("Workouts2Excersices")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Excercise", b =>
                {
                    b.Navigation("WorkoutTemplates2Excercises");

                    b.Navigation("Workouts2Excersices");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workout", b =>
                {
                    b.Navigation("Workouts2Excersices");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.WorkoutTemplate", b =>
                {
                    b.Navigation("WorkoutTemplates2Excercises");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("TrainingApp.Application.Entities.Workout.Workouts2Excersices", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
