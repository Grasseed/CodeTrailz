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
    public class APIUserController : ControllerBase
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
        public IActionResult UserSignUp([FromBody] User user)
        {
            var registeredUser = userModel.UserSignUp(user);
            if (registeredUser == null)
            {
                // Return a 400 Bad Request status code and a message if registration failed
                return BadRequest("Registration failed");
            }

            // Return a 200 OK status code and a success message
            return Ok("Registration successful");
        }
        #endregion
    }
}