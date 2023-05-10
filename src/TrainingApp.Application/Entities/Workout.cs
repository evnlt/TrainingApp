namespace TrainingApp.Application.Entities;

public class Workout
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public DateTime Date { get; set; } = DateTime.Today;

    public bool IsDone { get; set; }

    public ICollection<WorkoutExcersices> WorkoutExcersices { get; set; } = default!;

}
