using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TreeForSuccess.Model
{
    public class UserModel
    {
        private DapperServices _dapperServices;
        public byte[] HashPassword(string password)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(password));
        }


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
        public User? UserSignUp(User user)
        {
            string sql = @"INSERT INTO Users (Name, Gender, Mail, Password, DataStatus) 
                        VALUES (@Name, @Gender, @Mail, @Password, @DataStatus)";
            _dapperServices.ExecuteSQL(sql, user);
            return user; // Return the user object regardless of whether the SQL execution was successful
        }
    }
}