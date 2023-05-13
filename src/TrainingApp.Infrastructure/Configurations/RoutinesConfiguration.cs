using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Application.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TrainingApp.Infrastructure.Configurations;

internal class RoutinesConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.ToTable("Routines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

        builder.Property(x => x.DateTimes).HasConversion(new DateTimeCollectionConverter());
    }

    public class DateTimeCollectionConverter : ValueConverter<ICollection<DateTime>, string>
    {
        public DateTimeCollectionConverter(ConverterMappingHints mappingHints = null)
            : base(
                  d => ConvertToString(d),
                  s => ConvertToDateTimeCollection(s),
                  mappingHints)
        {
        }

        private static string ConvertToString(ICollection<DateTime> dates)
        {
            // Convert the ICollection<DateTime> to a comma-separated string
            return string.Join(",", dates);
        }

        private static ICollection<DateTime> ConvertToDateTimeCollection(string str)
        {
            // Convert the comma-separated string to an ICollection<DateTime>
            var dateStrings = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var dates = new List<DateTime>();
            foreach (var dateString in dateStrings)
            {
                if (DateTime.TryParse(dateString, out var date))
                {
                    dates.Add(date);
                }
            }
            return dates;
        }
    }
}
