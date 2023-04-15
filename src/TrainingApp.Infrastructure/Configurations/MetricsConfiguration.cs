using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

public class MetricsConfiguration : IEntityTypeConfiguration<Metric>
{
    public void Configure(EntityTypeBuilder<Metric> builder)
    {
        builder.ToTable("Metrics");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FatPercentage).IsRequired(false);
        builder.Property(x => x.MusclePercentage).IsRequired(false);
    }
}
