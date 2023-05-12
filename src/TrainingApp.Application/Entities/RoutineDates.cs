namespace TrainingApp.Application.Entities;

public class RoutineDates
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid RoutineId { get; set; }

    public Routine Routine { get; set; } = default!;

    public DateTime Date { get; set; }
}
