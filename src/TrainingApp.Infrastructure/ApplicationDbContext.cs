using Microsoft.EntityFrameworkCore;
using TrainingApp.Infrastructure.Entities;

namespace TrainingApp.Infrastructure;

public class ApplicationDbContext : DbContext
{

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Constructor for creating migrations
    /// </summary>
    public ApplicationDbContext()
    {
        File = Path.Combine("./", "UsedByMigratorOnly1.db3");
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
