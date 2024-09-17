using MyState.Utils;
using System;
using MyState.Models;
using Avalonia.Media;

namespace MyState.Scenarios.MyStates
{
    public class HistoryItem: ViewModelBase
    {
        public HistoryItem(ActionsHistoryItem model)
        {
            State = model.State;
            StateTime = model.StateTime;
        }

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
