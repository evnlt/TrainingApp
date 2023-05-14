namespace TrainingApp.Application.Entities;

public class Set
{
    public Guid Id { get; set; }

    //public Guid WorkoutExcerciseId { get; set; }

    public Guid WorkoutId { get; set; }

    public Workout Workout { get; set; } = default!;

    public Guid ExcerciseId { get; set; }

    public Excercise Excercise { get; set; } = default!;

    public WorkoutExcersices WorkoutExcercises { get; set; } = default!;

    public int Order { get; set; }

    public int Measure { get; set; }

    public int Reps { get; set; }

}
