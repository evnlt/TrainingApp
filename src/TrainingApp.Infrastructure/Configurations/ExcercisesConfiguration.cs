using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities.Workout;

namespace TrainingApp.Infrastructure.Configurations;

public class ExcercisesConfiguration : IEntityTypeConfiguration<Excercise>
{
    public void Configure(EntityTypeBuilder<Excercise> builder)
    {
        builder.ToTable("Excercise");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(64).IsRequired(false);
    }
}
