using Microsoft.Data.SqlClient;
using Dapper;

namespace TaskFlow.Data
{
    public static class DatabaseSetup
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=TaskFlow;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True;";

        public static void CriarBancoDeDados()
        {
            using var connection = new SqlConnection("Server=localhost,1433;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False;TrustServerCertificate=True;");
            connection.Execute("IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TaskFlow') CREATE DATABASE TaskFlow;");
        }

        public static void CriarTabela()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tasks')
                BEGIN
                    CREATE TABLE Tasks (
                        Id INT PRIMARY KEY IDENTITY,
                        Title NVARCHAR(255) NOT NULL,
                        Description NVARCHAR(MAX),
                        DueDate DATETIME NULL,
                        Status INT NOT NULL,
                        CategoryId INT NOT NULL,
                        CreatedAt DATETIME DEFAULT GETDATE(),
                        CONSTRAINT FK_Tasks_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
                    )
                END");
        }
        public static void CriarTabelaCategorias()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            connection.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories')
                BEGIN
                    CREATE TABLE Categories (
                        Id INT PRIMARY KEY IDENTITY,
                        Name NVARCHAR(255) NOT NULL
                    )
                END");
        }

    }
}

