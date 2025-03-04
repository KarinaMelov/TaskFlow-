using Dapper;
using Microsoft.Data.SqlClient;
using TaskFlow.Models;

namespace TaskFlow.Repositories
{
    public class CategoryRepository : Repository<TaskItem>
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection) : base(connection) 
        => _connection = connection;

        public List<Category> GetWithCategories()
        {
            var query = @"
                SELECT c.Id AS CategoryId, c.Name AS CategoryName, 
                       t.Id AS TaskId, t.Title, t.Status, t.CategoryId, t.DueDate 
                FROM Categories c
                LEFT JOIN Tasks t ON t.CategoryId = c.Id
                WHERE t.Title IS NOT NULL AND t.Title != '' ";

            var categories = new List<Category>();

            var items = _connection.Query<Category, TaskItem, Category>(
                query, 
                (category, task) =>
            {
                var ctgr = categories.FirstOrDefault(c => c.Id == category.Id);
                if (ctgr == null)
                {
                    ctgr = category;
                    if(task != null)
                        ctgr.Tasks.Add(task);
                    categories.Add(ctgr);
                }
                else 
                {
                    ctgr.Tasks.Add(task);
                }

                return ctgr;
            }, splitOn: "TaskId");
            return categories;
        }
    }
}
