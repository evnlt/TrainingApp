﻿namespace TrainingApp.Application.Entities.Workout;

public class Workout
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public Guid? WorkoutTemplateId { get; set; }

    public WorkoutTemplate? WorkoutTemplate { get; set; } = default!;

    public string? Notes { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    public bool IsDone { get; set; }

    public ICollection<Workouts2Excersices> Workouts2Excersices { get; set; } = default!;

}
