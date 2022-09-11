Task? task = Example<Task>.returnVoidTask();
Console.WriteLine(task != null ? task.ToString() : "Null");

task = Example<Task>.returnNull(task);
Console.WriteLine(task != null ? task.ToString() : "Null");

public class Example<T> where T : class
{
    public static async Task returnVoidTask()
    {
        return;
    }

    public static T? returnNull(T? entity)
    {
        return null;
    }
}