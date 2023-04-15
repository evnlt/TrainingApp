using TrainingApp.Infrastructure;

Console.WriteLine("Migrator running..");

using (var blogContext = new ApplicationDbContext())
{
    var all = blogContext.Excercises.ToList();
}