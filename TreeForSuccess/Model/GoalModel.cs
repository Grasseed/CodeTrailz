using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeForSuccess;

namespace TreeForSuccess.Model
{
    public class GoalModel
    {
        private DapperServices _dapperServices;

        public GoalModel(DapperServices dapperServices)
        {
            _dapperServices = dapperServices;
        }

        public bool SetGoal (Goal goalName)
        {
            string sql = "INSERT INTO dbo.Goal(UserID, GoalName) VALUES (@UserID, @GoalName)";
            var result = _dapperServices.ExecuteSQL(sql, goalName);
            return result; // Return the user object regardless of whether the SQL execution was successful
        }

        public Goal? GetGoalSetting (string GoalName)
        {
            string sql = "SELECT * FROM Goal WHERE GoalName=@GoalName";
            var result = _dapperServices.ExecuteSQLWithReturn<Goal>(sql, new { GoalName});
            return result;
        }
    }
}