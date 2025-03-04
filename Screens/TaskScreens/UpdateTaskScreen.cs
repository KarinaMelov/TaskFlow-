using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Repositories;
using TaskFlow.Screens.TaskScreens;

namespace TaskFlow.Screens
{
    public class UpdateTaskScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update task");
            Console.WriteLine("Enter the task Id to Update:");
            var id = int.Parse(Console.ReadLine());

            var repository = new Repository<TaskItem>(Database.Connection);
            var existingTask = repository.Get(id); // Buscar a tarefa original

            if (existingTask == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }


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


            Update(new TaskItem
            {
                Id = id,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = status,
                CategoryId = categoryId

            });
            Console.ReadKey();
            MenuTaskScreen.Load();
        }

        public static void Update(TaskItem taskItem)
        {
            try
            {
                var repository = new Repository<TaskItem>(Database.Connection);
                repository.Update(taskItem);
                Console.WriteLine("Task update successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the task.");
                Console.WriteLine(e.Message);
            }
        }
    }
}