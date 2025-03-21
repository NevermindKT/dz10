using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    public class Repository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public Repository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<T> GetAll(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return _dbConnection.Query<T>(query).ToList();
        }

        public T? GetById(string tableName, int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE Id = @Id";
            return _dbConnection.QueryFirstOrDefault<T>(query, new { Id = id });
        }

        public void Add(string tableName, T entity)
        {
            string query = $"INSERT INTO {tableName} (Name, Quantity) VALUES (@Name, @Quantity)";
            _dbConnection.Execute(query, entity);
        }

        public void Delete(string tableName, int id)
        {
            string query = $"DELETE FROM {tableName} WHERE Id = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }
    }
}