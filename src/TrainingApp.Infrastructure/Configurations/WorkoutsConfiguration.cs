using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities.Workout;

namespace TrainingApp.Infrastructure.Configurations;

internal class WorkoutsConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");

        builder.HasKey(x => x.Id);

        //builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Notes).HasMaxLength(1000).IsRequired(false);

        builder.HasOne(x => x.WorkoutTemplate).WithMany(x => x.Workouts).HasForeignKey(x => x.WorkoutTemplateId);
    }
}
