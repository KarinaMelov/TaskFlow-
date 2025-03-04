using System;
using Microsoft.Data.SqlClient;
using TaskFlow.Repositories;
using TaskFlow.Screens.CategoryScreens;
using TaskFlow.Screens.TaskScreens;

namespace TaskFlow.Screens
{
    public class MainMenuScreen
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=TaskFlow;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True;";

        public static void Load()
        {
            using (Database.Connection = new SqlConnection(CONNECTION_STRING))
            {
                Database.Connection.Open();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MAIN MENU");
                    Console.WriteLine("1 - Tasks");
                    Console.WriteLine("2 - Categories");
                    Console.WriteLine("0 - Exit");
                    Console.WriteLine();
                    
                    var option = short.Parse(Console.ReadLine()!);

                    switch (option)
                    {
                        case 1:
                            MenuTaskScreen.Load();
                            break;
                        case 2:
                            MenuCategoryScreen.Load();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid option. Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
