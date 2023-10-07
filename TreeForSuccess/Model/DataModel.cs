using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace TreeForSuccess.Model
{
    public class UserRequest
    {
        public Guid? GUID { get; set; }
        public required string Name { get; set; }
        public int Gender { get; set; }
        public required string Mail { get; set; }

        [JsonIgnore]
        public byte[] Password
        {
            get
            {
                return HashPassword(PasswordString);
            }
        }
        public required string PasswordString { get; set; }
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int DataStatus { get; set; }
        public byte[] HashPassword(string password)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(password));
        }
    }

	public class UserResponse
	{
		public Guid? GUID { get; set; }
		public required string Name { get; set; }
		public int Gender { get; set; }
		public required string Mail { get; set; }
		public DateTime? InsertTime { get; set; }
		public DateTime? UpdateTime { get; set; }

		[JsonIgnore]
		public byte[]? Password { get; set; }
		public int DataStatus { get; set; }
		public byte[] HashPassword(string password)
		{
			return SHA256.HashData(Encoding.UTF8.GetBytes(password));
		}
	}

	public class Login
    {
        public Guid? GUID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
		public required string PasswordString { get; set; }
		public byte[] Password
		{
			get
			{
				return HashPassword(PasswordString);
			}
		}

		public byte[] HashPassword(string password)
		{
			return SHA256.HashData(Encoding.UTF8.GetBytes(password));
		}
	}


    public class Goal
    {
        public Guid GUID { get; set; }
        public Guid UserID { get; set; }
        public required string GoalName { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int DataStatus { get; set; }
    }
}