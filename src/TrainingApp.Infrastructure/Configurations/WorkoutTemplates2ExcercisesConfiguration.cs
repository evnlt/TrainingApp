using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities.Workout;

namespace TrainingApp.Infrastructure.Configurations;

public class WorkoutTemplates2ExcercisesConfiguration : IEntityTypeConfiguration<WorkoutTemplates2Excercises>
{
    public void Configure(EntityTypeBuilder<WorkoutTemplates2Excercises> builder)
    {
        builder.ToTable("WorkoutTemplates_Excercises");

        builder.HasKey(x => x.Id);

        builder.HasOne(x=> x.WorkoutTemplate).WithMany(x => x.WorkoutTemplates2Excercises).HasForeignKey(x => x.WorkoutTemplateId);
        builder.HasOne(x => x.Excercise).WithMany(x => x.WorkoutTemplates2Excercises).HasForeignKey(x => x.ExcerciseId);
    }
}
