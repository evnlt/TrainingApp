using TrainingApp.Infrastructure;

Console.WriteLine("Migrator running..");

using (var db = new ApplicationDbContext())
{
    var all = db.Workouts.ToList();

    foreach (var workout in all)
    {
        Console.WriteLine(workout.Date + " " + workout.Name);
    }
}