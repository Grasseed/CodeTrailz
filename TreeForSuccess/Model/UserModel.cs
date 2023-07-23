using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeForSuccess.Model
{
    public class UserModel
    {
        private DapperServices _dapperServices;

        public UserModel(DapperServices dapperServices)
        {
            _dapperServices = dapperServices;
        }
        public User? GetUserInfo (string UserName)
        {
            string sql = "SELECT * FROM Users WHERE Name=@Name";
            var result = _dapperServices.ExecuteSQLWithReturn<User>(sql, new { Name = UserName});
            return result;
        }
    }
}