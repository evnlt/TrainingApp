using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class RoutinesConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.ToTable("Routines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

        builder.HasMany(x => x.Dates).WithOne(x => x.Routine).HasForeignKey(x => x.RoutineId);
    }
}
