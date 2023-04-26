namespace TrainingApp.Application.Entities.Workout;

public class WorkoutTemplate
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    //public int Image { get; set; } TODO - image?

    public bool IsBuiltIn { get; set; }

    public bool InUse { get; set; }

    public ICollection<WorkoutTemplates2Excercises>? WorkoutTemplates2Excercises { get; set; } = default!;

    public ICollection<Workout>? Workouts { get; set; } = default!;
}
