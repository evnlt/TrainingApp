using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class RoutineDatesConfiguration : IEntityTypeConfiguration<RoutineDates>
{
    public void Configure(EntityTypeBuilder<RoutineDates> builder)
    {
        builder.ToTable("RoutineDates");

        builder.HasKey(x => x.Id);
    }
}
