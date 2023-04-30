using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TrainingApp.Application.Entities;
using TrainingApp.Application.Entities.Workout;
using TrainingApp.Infrastructure.Configurations;

namespace TrainingApp.Infrastructure;

public class ApplicationDbContext : DbContext
{

    public DbSet<Metric> Metrics { get; set; }

    public DbSet<Excercise> Excercises { get; set; }

    public DbSet<Set> Sets { get; set; }

    public DbSet<Workout> Workouts { get; set; }

    public DbSet<Workouts2Excersices> Workouts2Excersices { get; set; }

    public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }

    public DbSet<WorkoutTemplates2Excercises> WorkoutTemplates2Excercises { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ExcercisesConfiguration());
        builder.ApplyConfiguration(new MetricsConfiguration());
        builder.ApplyConfiguration(new SetsConfiguration());
        builder.ApplyConfiguration(new Workouts2ExcersicesConfiguration());
        builder.ApplyConfiguration(new WorkoutsConfiguration());
        builder.ApplyConfiguration(new WorkoutTemplates2ExcercisesConfiguration());
        builder.ApplyConfiguration(new WorkoutTemplatesConfiguration());

        builder.Entity<Workout>().HasData(
        new Workout
        {
            Name = "Abs",
            Notes = "This is a note",
            Date = DateTime.Today,
            IsDone = false
        },
        new Workout
        {
            Name = "Pull",
            Notes = "This is a note",
            Date = DateTime.Today,
            IsDone = false
        },
        new Workout
        {
            Name = "Abs",
            Notes = "This is another note",
            Date = DateTime.Today.AddDays(-1),
            IsDone = true
        });

        builder.Entity<Excercise>().HasData(
        new Excercise
        {
            Name = "Pullups",
            IsBuiltIn = true,
            InUse = true
        },
        new Excercise
        {
            Name = "Ab curl",
            IsBuiltIn = true,
            InUse = true
        },
        new Excercise
        {
            Name = "Custom 1",
            IsBuiltIn = false,
            InUse = true
        });
    }

    /// <summary>
    /// Constructor for creating migrations
    /// </summary>
    public ApplicationDbContext()
    {
        File = Path.Combine("./", "UsedByMigratorOnly3.db3");
        Initialize();
    }

    /// <summary>
    /// Constructor for mobile app
    /// </summary>
    /// <param name="filenameWithPath"></param>
    public ApplicationDbContext(string filenameWithPath)
    {
        File = filenameWithPath;
        Initialize();
    }

    void Initialize()
    {
        if (!Initialized)
        {
            Initialized = true;

            SQLitePCL.Batteries_V2.Init();

            Database.Migrate();
        }
    }

    public static string File { get; protected set; }
    public static bool Initialized { get; protected set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite($"Filename={File}");
    }

    public void Reload()
    {
        Database.CloseConnection();
        Database.OpenConnection();
    }
}
