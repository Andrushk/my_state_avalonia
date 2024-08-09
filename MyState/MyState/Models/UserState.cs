using System;

namespace MyState.Models
{
    public enum UserStates {Unknown, AtWork, DayOff, Vacation, Sick}

    public class UserState
    {
        public string UserName { get; set; }

        public UserStates State { get; set; }

        public DateTime StateTime { get; set; }
    }
}
