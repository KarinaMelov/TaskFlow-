using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Repositories;

namespace TaskFlow.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete a category");
            Console.WriteLine("Enter the category Id:");
            var id = int.Parse(Console.ReadLine()!);

            Delete(id);
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Category deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not delete the category.");
                Console.WriteLine(e.Message);
            }
        }
    }
}