using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IDbConnection GetConnection();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
        void InsertAsync(TEntity entity);
        void DeleteAsync(Guid id);
        void UpdateAsync(TEntity entity);
        Task<IEnumerable<T>> ExecuteQuery<T>(string commandText, object objectParams, CommandType commandType);
        Task<IEnumerable<TEntity>> GetByExpression(Func<TEntity, bool> predicate, int number = 10);
    }
}
