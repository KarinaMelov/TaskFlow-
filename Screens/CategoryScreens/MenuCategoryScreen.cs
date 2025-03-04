using TaskFlow.Screens.CategoryScreens;

namespace TaskFlow.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Categories Menu");
            Console.WriteLine("1 - List categories");
            Console.WriteLine("2 - Create category");
            Console.WriteLine("3 - Update category");
            Console.WriteLine("4 - Delete category");
            Console.WriteLine("0 - Return");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;
                case 0:
                    MainMenuScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}