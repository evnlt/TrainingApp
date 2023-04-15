namespace TrainingApp.Application.Entities.Workout;

public class Workouts2Excersices
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid WorkoutId { get; set; }

    public Workout Workout { get; set; } = default!;

    public Guid ExcerciseId { get; set; }

    public Excercise Excercise { get; set; } = default!;

    public int Order { get; set; }

    public ICollection<Set> Sets { get; set; } = default!;
}
