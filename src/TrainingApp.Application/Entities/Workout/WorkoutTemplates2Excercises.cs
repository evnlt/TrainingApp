namespace TrainingApp.Application.Entities.Workout;

public class WorkoutTemplates2Excercises
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid WorkoutTemplateId { get; set; }

    public WorkoutTemplate WorkoutTemplate { get; set; } = default!;

    public Guid ExcerciseId { get; set; }

    public Excercise Excercise { get; set; } = default!;

    public int Order { get; set; }
}
