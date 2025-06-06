using System;

namespace BackEndAPI.Models
{
    public class UserDetailsResponse
    {
        public UserInfo User { get; set; }
        public PersonalDataInfo PersonalData { get; set; }
    }

    public class UserInfo
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Username { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserDob { get; set; }
    }

    public class PersonalDataInfo
    {
        public GoalInfo Goal { get; set; }
        public double WeightKg { get; set; }
        public int HeightCm { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ActivityLevel { get; set; }
    }

    public class GoalInfo
    {
        public string GoalType { get; set; }
        public string Description { get; set; }
    }
} 