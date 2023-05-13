using Microsoft.EntityFrameworkCore;
using TrainingApp.Application.Common.Interfaces;
using TrainingApp.Application.Entities;
using TrainingApp.Application.Enums;
using TrainingApp.Infrastructure.Configurations;

namespace TrainingApp.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public DbSet<Excercise> Excercises { get; set; }

    public DbSet<Set> Sets { get; set; }

    public DbSet<Workout> Workouts { get; set; }

    public DbSet<WorkoutExcersices> WorkoutExcersices { get; set; }

    public DbSet<Routine> Routines { get; set; }

    public DbSet<RoutineExcersices> RoutineExcersices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ExcercisesConfiguration());
        builder.ApplyConfiguration(new SetsConfiguration());
        builder.ApplyConfiguration(new WorkoutsConfiguration());
        builder.ApplyConfiguration(new WorkoutExcersicesConfiguration());
        builder.ApplyConfiguration(new RoutinesConfiguration());
        builder.ApplyConfiguration(new RoutineExcersicesConfiguration());

        builder.Entity<Workout>().HasData(
        new Workout
        {
            Name = "Abs",
            Date = DateTime.Today,
            IsDone = false
        },
        new Workout
        {
            Name = "Pull",
            Date = DateTime.Today,
            IsDone = false
        },
        new Workout
        {
            Name = "Abs",
            Date = DateTime.Today.AddDays(-1),
            IsDone = true
        });

        builder.Entity<Routine>().HasData(
        new Routine
        {
            Name = "Abs",
            DateTimes = new List<DateTime>()
        },
        new Routine
        {
            Name = "Pull",
            DateTimes = new List<DateTime>()
        }) ;

        builder.Entity<Excercise>().HasData(
        new Excercise
        {
            Name = "Pullups",
            IsBuiltIn = true,
            ExcersiceType = ExcersiceType.Weight
        },
        new Excercise
        {
            Name = "Ab curl",
            IsBuiltIn = true,
            ExcersiceType = ExcersiceType.Weight
        },
        new Excercise
        {
            Name = "Custom 1",
            IsBuiltIn = false,
            ExcersiceType = ExcersiceType.Time
        });
    }

    /// <summary>
    /// Constructor for creating migrations
    /// </summary>
    public ApplicationDbContext()
    {
        File = Path.Combine("./", "MigratorDb007.db3");
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
