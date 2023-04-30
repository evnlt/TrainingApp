using TrainingApp.Infrastructure;

Console.WriteLine("Migrator running..");

using (var db = new ApplicationDbContext())
{
    var workouts = db.Workouts.ToList();

    foreach (var workout in workouts)
    {
        Console.WriteLine(workout.Date + " " + workout.Name);
    }

    Console.WriteLine("\n");

    var excercises = db.Excercises.ToList();

    foreach (var excercise in excercises)
    {
        Console.WriteLine(excercise.Name + " " + excercise.IsBuiltIn);
    }
}