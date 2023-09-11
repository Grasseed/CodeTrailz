using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
            try
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
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        // Get Goal Setting
        [HttpGet("GetGoalSetting")]
        public IActionResult GetGoalSetting([FromBody] string GoalName)
        {
            try
            {
                var goalSetting = goalModel.GetGoalSetting(GoalName);
                if (goalModel == null)
                {
					// Return a 400 Bad Request status code and a message if registration failed
					return BadRequest("Get goal settings failed");
				}

				// Return a 200 OK status code and get goal settings
				return Ok(JsonSerializer.Serialize(goalModel.GetGoalSetting(GoalName), JsonSettings.GetJsonSettings()));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}

