using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrainingApp.Application.Entities;

namespace TrainingApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Excercise> Excercises { get; set; }

    DbSet<Set> Sets { get; set; }

    DbSet<Workout> Workouts { get; set; }

    DbSet<WorkoutExcersices> WorkoutExcersices { get; set; }

    DbSet<Routine> Routines { get; set; }

    DbSet<RoutineExcersices> RoutineExcersices { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
