using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class WorkoutExcersicesConfiguration : IEntityTypeConfiguration<WorkoutExcersices>
{
    public void Configure(EntityTypeBuilder<WorkoutExcersices> builder)
    {
        builder.ToTable("WorkoutExcercises");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Workout).WithMany(x => x.WorkoutExcersices).HasForeignKey(x => x.WorkoutId);
        builder.HasOne(x => x.Excercise).WithMany(x => x.WorkoutExcersices).HasForeignKey(x => x.ExcerciseId);
    }
}
