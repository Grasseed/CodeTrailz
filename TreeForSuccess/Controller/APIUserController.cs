using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeForSuccess.Model;
using TreeForSuccess.Utilities;

namespace TreeForSuccess.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class APIUserController
    {
        #region APIs

        private readonly UserModel userModel;

        public APIUserController(UserModel _userModel)
        {
            userModel = _userModel;
        }

        // Get User Informations
        [HttpGet("GetUserInfo")]
        public ActionResult<string> GetUserInfo(string UserName)
        {
            return JsonSerializer.Serialize(userModel.GetUserInfo(UserName), JsonSettings.GetJsonSettings());
        }

        // User Sign Up Account
        [HttpPost("UserSignUp")]
        public ActionResult<object> UserSignUp(object obj)
        {
            return JsonSerializer.Serialize(obj, JsonSettings.GetJsonSettings());
        }
        #endregion
    }
}