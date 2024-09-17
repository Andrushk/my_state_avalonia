using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyState.Services;
using MyState.Utils;

namespace MyState.Scenarios.TeamStates
{
    public partial class TeamStatesViewModel : ViewModelBase
    {
        public ObservableCollection<UserStateViewModel> States { get; } = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RefreshCommand))]
        [NotifyPropertyChangedFor(nameof(BusyOpacity))]
        private bool _busy = false;

        public double BusyOpacity => Busy ? .4 : 1.0;

        public TeamStatesViewModel()
        {
            TeamService.MyTeamStateChanged += TeamService_MyTeamStateChanged;
            _refresh();
        }

        [RelayCommand(CanExecute = nameof(CanRefresh))]
        private void Refresh() => _refresh();

        private bool CanRefresh() => !Busy;

        private async void _refresh()
        {
            //Debug.WriteLine("Refresh!!!!");
            Busy = true;
            TeamService.RefreshMyTeamState();
        }

        private void TeamService_MyTeamStateChanged(object? sender, System.Collections.Generic.List<Models.UserState> e)
        {
            States.Clear();
            foreach (var i in e)
            {
                States.Add(new UserStateViewModel(i));
            }

            Busy = false;
        }
    }
}