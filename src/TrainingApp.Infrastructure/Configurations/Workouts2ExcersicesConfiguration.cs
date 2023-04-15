using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities.Workout;

namespace TrainingApp.Infrastructure.Configurations;

internal class Workouts2ExcersicesConfiguration : IEntityTypeConfiguration<Workouts2Excersices>
{
    public void Configure(EntityTypeBuilder<Workouts2Excersices> builder)
    {
        builder.ToTable("Workout_Excercises");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Workout).WithMany(x => x.Workouts2Excersices).HasForeignKey(x => x.WorkoutId);
        builder.HasOne(x => x.Excercise).WithMany(x => x.Workouts2Excersices).HasForeignKey(x => x.ExcerciseId);
    }
}
