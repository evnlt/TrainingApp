using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

public class SetsConfiguration : IEntityTypeConfiguration<Set>
{
    public void Configure(EntityTypeBuilder<Set> builder)
    {
        builder.ToTable("Sets");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.WorkoutExcercises).WithMany(x => x.Sets).HasForeignKey(x => new { x.WorkoutId, x.ExcerciseId });
    }
}
