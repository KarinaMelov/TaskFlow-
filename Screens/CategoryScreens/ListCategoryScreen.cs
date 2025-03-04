using TaskFlow.Models;
using TaskFlow.Repositories;

namespace TaskFlow.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        public static void Load(){
            Console.Clear();
            Console.WriteLine("List of Categories");
            ListCategories();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void ListCategories()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.Get();
            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.Id} - Name: {category.Name}");
            }
        }
    }
}