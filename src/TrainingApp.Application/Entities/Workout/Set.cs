namespace TrainingApp.Application.Entities.Workout;

public class Set
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid WorkoutExcerciseId { get; set; }

    public Workouts2Excersices Workouts2Excercises { get; set; } = default!;

    public int Order { get; set; }

    public float Weight { get; set; }

    public int Reps { get; set; }

}
