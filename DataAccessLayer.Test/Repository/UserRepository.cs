using DataAccessLayer.Repository;
using DataAccessLayer.Test.Entity;
using DataAccessLayer.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Test.Repository
{
    public class UserRepository : SQliteRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<string> GetUserNameReverseAsync(Guid id)
        {
            var result = await this.GetAsync(id);
            result.FirstName = string.Join("",result.FirstName.ToCharArray().Reverse());
            return result.FirstName;
        }
    }
}
