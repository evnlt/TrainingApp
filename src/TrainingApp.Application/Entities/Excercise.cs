using TrainingApp.Application.Enums;

namespace TrainingApp.Application.Entities;

public class Excercise
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public ExcersiceType ExcersiceType { get; set; }

    public bool IsBuiltIn { get; set; }

    public ICollection<WorkoutExcersices> WorkoutExcersices { get; set; } = default!;

    public ICollection<RoutineExcersices> RoutineExcersices { get; set; } = default!;
}
