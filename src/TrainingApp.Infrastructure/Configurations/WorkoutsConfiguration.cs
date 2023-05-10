using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class WorkoutsConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
    }
}
