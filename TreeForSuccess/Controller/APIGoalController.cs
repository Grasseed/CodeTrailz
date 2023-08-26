using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TreeForSuccess;
using Microsoft.VisualBasic;
using TreeForSuccess.Model;
using TreeForSuccess.Utilities;

namespace APIGoalController{
    [ApiController]
    [Route("[controller]")]
    public class APIGoalController : ControllerBase
    {
        #region APIs

        private readonly GoalModel goalModel;

        public APIGoalController(GoalModel _goalModel)
        {
            goalModel = _goalModel;
        }
        
        // Get Goal Setting
        [HttpPost("SetGoal")]
        public IActionResult SetGoal([FromBody] Goal goal)
        {
             var setGoal = goalModel.SetGoal(goal);
            if (setGoal == null)
            {
                // Return a 400 Bad Request status code and a message if registration failed
                return BadRequest("Set failed");
            }

            // Return a 200 OK status code and a success message
            return Ok("Set successful");
        }
        // Get Goal Setting
        [HttpGet("GetGoalSetting")]
        public ActionResult<string> GetGoalSetting(string GoalName)
        {
            return JsonSerializer.Serialize(goalModel.GetGoalSetting(GoalName), JsonSettings.GetJsonSettings());
        }
        #endregion
    }
}

