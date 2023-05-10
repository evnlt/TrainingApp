using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Application.Entities;

namespace TrainingApp.Infrastructure.Configurations;

internal class RoutineExcersicesConfiguration : IEntityTypeConfiguration<RoutineExcersices>
{
    public void Configure(EntityTypeBuilder<RoutineExcersices> builder)
    {
        builder.ToTable("RoutineExcercises");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Routine).WithMany(x => x.RoutineExcersices).HasForeignKey(x => x.RoutineId);
        builder.HasOne(x => x.Excercise).WithMany(x => x.RoutineExcersices).HasForeignKey(x => x.ExcerciseId);
    }
}
