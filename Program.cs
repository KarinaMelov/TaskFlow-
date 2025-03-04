using Microsoft.Data.SqlClient;
using TaskFlow.Repositories;
using TaskFlow.Screens;

class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=TaskFlow;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        using (Database.Connection = new SqlConnection(CONNECTION_STRING))
        {
            Database.Connection.Open();
            MainMenuScreen.Load(); // Chama o menu principal
        }
    }
}
