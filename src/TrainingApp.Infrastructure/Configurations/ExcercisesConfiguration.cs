using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

public class ExcercisesConfiguration : IEntityTypeConfiguration<Excercise>
{
    public void Configure(EntityTypeBuilder<Excercise> builder)
    {
        builder.ToTable("Excercises");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
    }
}
