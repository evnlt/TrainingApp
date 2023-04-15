namespace TrainingApp.Application.Entities;

public class Metric
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public float Weight { get; set; }

    public float? FatPercentage { get; set; } = default!;

    public float? MusclePercentage { get; set; } = default!;
}
