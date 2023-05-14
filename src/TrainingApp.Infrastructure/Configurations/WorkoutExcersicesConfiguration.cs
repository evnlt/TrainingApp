using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class WorkoutExcersicesConfiguration : IEntityTypeConfiguration<WorkoutExcersices>
{
    public void Configure(EntityTypeBuilder<WorkoutExcersices> builder)
    {
        builder.ToTable("WorkoutExcercises");

        //builder.HasKey(x => x.Id);
        builder.HasKey(x => new {x.WorkoutId, x.ExcerciseId});

        builder.HasOne(x => x.Workout).WithMany(x => x.WorkoutExcersices).HasForeignKey(x => x.WorkoutId);
        builder.HasOne(x => x.Excercise).WithMany(x => x.WorkoutExcersices).HasForeignKey(x => x.ExcerciseId);

        builder.Property(x => x.WorkoutId).ValueGeneratedNever();
        builder.Property(x => x.ExcerciseId).ValueGeneratedNever();
    }

    public class WorkoutExcerciseId
    {
        public Guid WorkoutId { get; set; }

        public Guid ExerciseId { get; set; }
    }
}
