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

        public Goal? GetGoalSetting (string GoalName)
        {
            string sql = "SELECT * FROM Goal WHERE GoalName=@Goal";
            var result = _dapperServices.ExecuteSQLWithReturn<Goal>(sql, new { Goal = GoalName});
            return result;
        }
    }
}