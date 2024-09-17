using MyState.Utils;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using MyState.Models;
using MyState.Services;
using MyState.Scenarios.TeamStates;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyState.Scenarios.MyStates
{
    public partial class MyStatesViewModel : ViewModelBase
    {
        public ObservableCollection<HistoryItem> History { get; } = new();

        [RelayCommand]
        private async void AtWork()
        {
            await SetState(UserStates.AtWork);

            //var box = MessageBoxManager.GetMessageBoxStandard("Caption", "Your state set to 'AtWork'");
            //var result = await box.ShowAsync();
        }

        [RelayCommand]
        private async void DayOff()
        {
            await SetState(UserStates.DayOff);


            var box = MessageBoxManager.GetMessageBoxStandard("Caption", "Your state set to 'DayOff'");
            var result = await box.ShowAsync();
        }

        [RelayCommand]
        private async void Sick()
        {
            await SetState(UserStates.Sick);

            var box = MessageBoxManager.GetMessageBoxStandard("Caption", "Your state set to 'Sick'");
            var result = await box.ShowAsync();
        }

        private async Task SetState(UserStates state)
        {
            await TeamService.AddState(state);

            RefreshHistory();
        }

        private void RefreshHistory()
        {
            History.Clear();
            foreach (var item in TeamService.GetMyHistory().OrderByDescending(x => x.StateTime))
            {
                History.Add(new HistoryItem(item));
            }
        }
    }
}