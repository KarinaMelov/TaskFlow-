using TaskFlow;
using TaskFlow.Repositories;

namespace TaskFlow.Screens.TaskScreens
{
    public class ListTaskScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List of tasks");
            ListTasks();
            Console.ReadKey();
            MenuTaskScreen.Load();
        }
        public static void ListTasks()
        {
           var repository = new Repository<TaskItem>(Database.Connection);
           var tasks = repository.Get();
              foreach (var task in tasks)
              {
                Console.WriteLine($"Id: {task.Id} - Name: {task.Title}");
              }
        }
    }
}