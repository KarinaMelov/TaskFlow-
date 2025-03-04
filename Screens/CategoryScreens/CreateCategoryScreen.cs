using TaskFlow.Models;
using TaskFlow.Repositories;
using TaskFlow.Screens.TaskScreens;

namespace TaskFlow.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Create a new category");
            Console.WriteLine("Enter the category name:");
            var name = Console.ReadLine();

            Create(new Category { Name = name });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Category created successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create the category.");
                Console.WriteLine(e.Message);
            }

        }
    }
}
