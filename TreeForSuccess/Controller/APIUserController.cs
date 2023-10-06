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

		// User loggin
		[HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                if ( (string.IsNullOrEmpty(login.Name) && string.IsNullOrEmpty(login.Mail)) || string.IsNullOrEmpty(login.PasswordString))
                {
					return BadRequest("Login failed, one or more required parameter not received");
				}

				// Return a 200 OK status code and login success
				return Ok(userModel.Login(login) ? "Login success" : "Login failed");
			}
            catch (Exception ex)
            {
                return BadRequest("Login failed");
			}
        }

		// Get User Informations
		[HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(string userName, string mail)
        {
            try
            {
                var userInfo = userModel.GetUserInfo(userName, mail);
                if (userInfo == null)
                {
				    // Return a 400 Bad Request status code and a message if get user info failed
				    return BadRequest("Get user info failed");
			    }

			    // Return a 200 OK status code and user info
			    return Ok(JsonSerializer.Serialize(userInfo, JsonSettings.GetJsonSettings()));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // User Sign Up Account
        [HttpPost("UserSignUp")]
        public IActionResult UserSignUp(UserRequest user)
        {
            try
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
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}