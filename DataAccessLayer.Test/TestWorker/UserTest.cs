using DataAccessLayer.Test.Entity;
using DataAccessLayer.Test.Interfaces;
using DataAccessLayer.Test.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Test.Utility.ConsoleExtension;

namespace DataAccessLayer.Test.TestWorker
{
    public class UserTest
    {
        private readonly IUserRepository _userRepository;
        public UserTest(IConfiguration config)
        {
            WriteLineYellow("Rise of User Repository");
            _userRepository = new UserRepository(config["ConnectionString"]);
        }

        public async Task UserRepositoryTestAsync()
        {
            WriteLineYellow("_userRepository GetAllAsync metod execute");
            var result = _userRepository.GetAllAsync().GetAwaiter().GetResult();

            if (result.Count() > 0)
            {
                WriteLineYellow("_userRepository ExecuteQuery metod execute");
                var query1 = await _userRepository.ExecuteQuery<User>("Select * From TBLUser Where FirstName = @FirstName", new { FirstName = "Ahmet" }, System.Data.CommandType.Text);
                
                WriteLineYellow("_userRepository GetByExpression metod execute");
                var query2 = await _userRepository.GetByExpression(a => a.LastName.Contains("G"));

                WriteLineYellow("_userRepository GetAsync metod execute");
                var query3 = await _userRepository.GetAsync(result.First().Id);

                {
                    var updateObj = result.First();
                    updateObj.FirstName = "Test Adı";
                    WriteLineYellow("_userRepository UpdateAsync metod execute");
                    _userRepository.UpdateAsync(updateObj);
                    var query4 = _userRepository.GetAsync(updateObj.Id);
                }
                WriteLineYellow("_userRepository GetUserNameReverseAsync metod execute");
                var query5 = await _userRepository.GetUserNameReverseAsync(result.First().Id);

                if (true)
                {
                    WriteLineYellow("_userRepository DeleteAsync metod execute");
                    _userRepository.DeleteAsync(result.First().Id);
                }

            }
            else
            {
                WriteLineYellow("_userRepository InsertAsync metod execute");
                _userRepository.InsertAsync(new Entity.User { Id = Guid.NewGuid(), FirstName = "Ahmet", LastName = "Gençözlü" });
            }
            WriteLineGreen("Success !");
        }
    }
}
