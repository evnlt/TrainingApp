using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Application.Entities;

public class RoutineExcersices
{
    //public Guid Id { get; set; } = Guid.NewGuid();

    public Guid RoutineId { get; set; }

    public Routine Routine { get; set; } = default!;

    public Guid ExcerciseId { get; set; }

    public Excercise Excercise { get; set; } = default!;

    public int Order { get; set; }
}
