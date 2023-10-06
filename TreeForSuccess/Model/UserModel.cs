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
        public bool Login(Login login)
        {
            try
            {
                if ( (string.IsNullOrEmpty(login.Name) && string.IsNullOrEmpty(login.Mail)) || string.IsNullOrEmpty(login.PasswordString) )
                {
                    return false;
                }

                var user = GetUserInfo(login.Name, login.Mail);

				if (user == null)
				{
					return false;
				}

				byte[] hashedPassword = HashPassword(login.PasswordString);

				if (!user.Password.SequenceEqual(hashedPassword))
				{
					return false;
				}
                return true;
			}
            catch (Exception ex)
            {
                return false;
            }
        }
        public UserResponse? GetUserInfo (string? UserName, string? Mail)
        {
            var sql = "SELECT [GUID], [Name], [Mail], [Password] FROM [Users] WHERE 1 = 1";
            if (UserName != null)
            {
                sql += "AND [Name] = @Name ";
			}
            if (Mail != null)
            {
                sql += "AND [Mail] = @Mail ";
			}
            
			var parameters = new { Name = UserName, Mail = Mail };
			var result = _dapperServices.ExecuteSQLWithReturn<UserResponse>(sql, parameters);
            return result;
        }
        public UserRequest? UserSignUp(UserRequest user)
        {
            string sql = @"INSERT INTO Users (Name, Gender, Mail, Password, DataStatus) 
                        VALUES (@Name, @Gender, @Mail, @Password, @DataStatus)";
            _dapperServices.ExecuteSQL(sql, user);
            return user; // Return the user object regardless of whether the SQL execution was successful
        }
    }
}