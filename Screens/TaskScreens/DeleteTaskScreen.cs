using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Repositories;

namespace TaskFlow.Screens.TaskScreens
{
     public class DeleteTaskScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete task");
            Console.WriteLine("Enter the task Id to delete:");
            var id = int.Parse(Console.ReadLine());
            

            
            Delete(id);
            Console.ReadKey();
            MenuTaskScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<TaskItem>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Task deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not delete the task.");
                Console.WriteLine(e.Message);
            }
        }
    }
}