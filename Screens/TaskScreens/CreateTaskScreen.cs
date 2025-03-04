using TaskFlow.Repositories;

namespace TaskFlow.Screens.TaskScreens
{
    public class CreateTaskScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Create task");
            Console.WriteLine("Enter the task title:");
            var title = Console.ReadLine();
            Console.WriteLine("Enter the task description:");
            var description = Console.ReadLine();
            Console.WriteLine("Enter the task DueDate:");
            var dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the task Status:");
            var status = Enum.Parse<TaskStatus>(Console.ReadLine());
            Console.WriteLine("Enter the task CategoryId:");
            var categoryId = int.Parse(Console.ReadLine());
            Create(new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = status,
                CategoryId = categoryId
            });
            Console.ReadKey();
            MenuTaskScreen.Load();
        }
        public static void Create(TaskItem taskItem)
        {
            try
            {
                var repository = new Repository<TaskItem>(Database.Connection);
                repository.Create(taskItem);
                Console.WriteLine("Task created successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create the task.");
                Console.WriteLine(e.Message);
            }
        }
    }
}