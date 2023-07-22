using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeForSuccess;
using TreeForSuccess.Model;

namespace TreeForSuccess
{
    public class GoalModel
    {
        private DapperServices _dapperServices;

        public GoalModel(DapperServices dapperServices)
        {
            _dapperServices = dapperServices;
        }

        public Goal? GetGoalSetting (string GoalName)
        {
            string sql = "SELECT * FROM Goal WHERE GoalName=@Goal";
            var result = _dapperServices.ExecuteSQLWithReturn<Goal>(sql, new { Goal = GoalName});
            return result;
        }

        public User? GetUserInfo (string UserName)
        {
            string sql = "SELECT * FROM Users WHERE Name=@Name";
            var result = _dapperServices.ExecuteSQLWithReturn<User>(sql, new { Name = UserName});
            return result;
        }

    }
}