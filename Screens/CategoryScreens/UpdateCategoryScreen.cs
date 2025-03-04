using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Models;
using TaskFlow.Repositories;

namespace TaskFlow.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load(){
            Console.Clear();
            Console.WriteLine("Update a category");
            Console.WriteLine("Enter the category Id:");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter the category name:");
            var name = Console.ReadLine();

            Update(new Category { Id = id, Name = name });
            Console.ReadKey();
            MenuCategoryScreen.Load();  
        }

        public static void Update(Category category){
            try {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
                Console.WriteLine("Category updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update the category.");
                Console.WriteLine(e.Message);
            }   
        }
    }
}