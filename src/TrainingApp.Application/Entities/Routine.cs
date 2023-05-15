namespace TrainingApp.Application.Entities;

public class Routine
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public ICollection<DateTime> DateTimes { get; set; } = default!;

    public ICollection<RoutineExcersices> RoutineExcersices { get; set; } = new List<RoutineExcersices>();

}
