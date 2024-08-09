using MyState.Models;
using MyState.Utils;
using System;
using Avalonia.Media;

namespace MyState.Scenarios.TeamStates
{
    public partial class UserStateViewModel: ViewModelBase
    {
        public UserStateViewModel(UserState model)
        {
            UserName = model.UserName;
            State = model.State;
            StateTime = model.StateTime;
        }

        public string UserName { get; }

        public UserStates State { get; }

        public IImmutableSolidColorBrush StateBrush
        {
            get
            {
                switch (State)
                {
                    case UserStates.AtWork:
                        return Brushes.Green;
                    case UserStates.DayOff:
                        return Brushes.Yellow;
                    case UserStates.Sick:
                        return Brushes.Red;
                    case UserStates.Unknown:
                        return Brushes.Silver;
                    case UserStates.Vacation:
                        return Brushes.LightBlue;
                }

                return Brushes.Transparent;
            }
        }

        public DateTime StateTime { get; }
    }
}
