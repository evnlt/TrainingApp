namespace TrainingApp.Application.Entities;

public class Set
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid WorkoutExcerciseId { get; set; }

    public WorkoutExcersices WorkoutExcercises { get; set; } = default!;

    public int Order { get; set; }

    public int Measure { get; set; }

    public int Reps { get; set; }

}
