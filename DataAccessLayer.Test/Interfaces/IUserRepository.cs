using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Test.Entity;

namespace DataAccessLayer.Test.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<string> GetUserNameReverseAsync(Guid id);
    }
}
