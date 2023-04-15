namespace TrainingApp.Application.Entities.Workout;

public class Excercise
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string? Description { get; set; } 

    //public int Image { get; set; } // TODO - image

    //public int Video { get; set; } // TODO - video

    public bool IsBuiltIn { get; set; }

    public bool InUse { get; set; }

    public ICollection<WorkoutTemplates2Excercises> WorkoutTemplates2Excercises { get; set; } = default!;

    public ICollection<Workouts2Excersices> Workouts2Excersices { get; set; } = default!;
}
