using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeForSuccess.Model
{
    public class User
    {
        public Guid GUID { get; set; }
        public required string Name { get; set; }
        public int Gender { get; set; }
        public required string Mail { get; set; }
        public required byte[] Password { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int DataStatus { get; set; }
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