namespace TaskFlow.Screens.TaskScreens
{
    public class MenuTaskScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Tasks Menu");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - List tasks");
            Console.WriteLine("2 - Create task");
            Console.WriteLine("3 - Update task");
            Console.WriteLine("4 - Delete task");
            Console.WriteLine("0 - Return");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListTaskScreen.Load();
                    break;
                case 2:
                    CreateTaskScreen.Load();
                    break;
                case 3:
                    UpdateTaskScreen.Load();
                    break;
                case 4:
                    DeleteTaskScreen.Load();
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