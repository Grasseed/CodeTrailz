using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TreeForSuccess.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class APIUsersController
    {
        #region BasicSetting
        // JSON 中文設定不轉換Unicode
        private static JsonSerializerOptions GetJsonSettings()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return options;
        }

        #endregion

        #region APIs

        private readonly GoalModel goalModel;

        public APIUsersController(GoalModel _goalModel)
        {
            goalModel = _goalModel;
        }

        // Get User Informations
        [HttpGet("GetUserInfo")]
        public ActionResult<string> GetUserInfo(string UserName)
        {
            return JsonSerializer.Serialize(goalModel.GetUserInfo(UserName), GetJsonSettings());
        }

        // User Sign Up Account
        [HttpPost("UserSignUp")]
        public ActionResult<object> UserSignUp(object obj)
        {
            return JsonSerializer.Serialize(obj, GetJsonSettings());
        }
        #endregion
    }
}