using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyState.Models;

namespace MyState.Services
{
    //TODO переделать на DI
    public static class TeamService
    {
        private static List<UserState> _myTeam = new List<UserState>()
        {
            new UserState
            {
                UserName = "Sergey", State = UserStates.AtWork, StateTime = DateTime.Today.AddHours(7)
            },
            new UserState
            {
                UserName = "Katerina", State = UserStates.AtWork, StateTime = DateTime.Today.AddHours(5)
            },
            new UserState
            {
                UserName = "Andrey", State = UserStates.Unknown, StateTime = DateTime.Today.AddDays(-1)
            },
        };


        public static async Task<IEnumerable<UserState>> GetMyTeam()
        {
            await Task.Delay(800);
            return _myTeam;
        }

    }
}
