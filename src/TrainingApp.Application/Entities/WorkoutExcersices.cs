﻿namespace TrainingApp.Application.Entities;

public class WorkoutExcersices
{

    public Guid WorkoutId { get; set; }

    public Workout Workout { get; set; } = default!;

    public Guid ExcerciseId { get; set; }

    public Excercise Excercise { get; set; } = default!;

    public int Order { get; set; }

    public ICollection<Set> Sets { get; set; } = new List<Set>();
} 
