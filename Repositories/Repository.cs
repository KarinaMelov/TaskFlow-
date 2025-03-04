using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace TaskFlow.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> Get()
        => _connection.GetAll<T>();

        public T Get(int Id)
        => _connection.Get<T>(Id);

        public void Create(T model)
         => _connection.Insert<T>(model);

        public void Update(T model)
          => _connection.Update<T>(model);

        public void Delete(T model)
            => _connection.Delete<T>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<T>(id); // Recupera a tarefa antes de excluir
            if (model != null) // Verifica se a tarefa existe antes de tentar excluir
            {
                _connection.Delete<T>(model);
            }
            else
            {
                Console.WriteLine("Task not found. Cannot delete.");
            }
        }

    }
}
