using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SQliteRepository<TEntity> : RepositoryQueryGenerator<TEntity>, IBaseRepository<TEntity> where TEntity : class
    {
        private string _connectionString;
        private DbConnectionTypes _dbType;
        private string _tableName;
        private string _pkProperty;

        public SQliteRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dbType = DbConnectionTypes.SQlite;
            _tableName = typeof(TEntity).GetTableAttribute();
            _pkProperty = typeof(TEntity).GetPropertyAttributes().Where(a => a.IsPrimaryKey == true).FirstOrDefault().PropertName;
        }

        public IDbConnection GetConnection()
        {
            return DbConnectionFactory.GetDbConnection(_dbType, _connectionString);
        }

        public async void DeleteAsync(Guid id)
        {
            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE {_pkProperty} = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<TEntity>($"SELECT * FROM {_tableName}");
            }
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            using (var connection = GetConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {_tableName} WHERE {_pkProperty} = @Id", new { Id = id });

                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");

                return result;
            }
        }

        public async Task<IEnumerable<TEntity>> GetByExpression(Func<TEntity, bool> predicate, int number = 10)
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<TEntity>($"SELECT * FROM {_tableName}")).Where(predicate);
            }
        }

        public async void InsertAsync(TEntity entity)
        {
            var insertQuery = GenerateInsertQuery(_tableName);

            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(insertQuery, entity);
            }
        }

        public async void UpdateAsync(TEntity entity)
        {
            var updateQuery = GenerateUpdateQuery(_tableName, _pkProperty);

            using (var connection = GetConnection())
            {
                await connection.ExecuteAsync(updateQuery, entity);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string commandText, object objectParams, CommandType commandType)
        {
            using (var conn = GetConnection())
            {
                var list = await conn.QueryAsync<T>(commandText, objectParams, commandType: commandType);
                return list;
            }

        }
    }
}
