using MyState.Utils;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
namespace MyState.Scenarios.MyStates
{
    public partial class MyStatesViewModel: ViewModelBase
    {
        [RelayCommand]
        private async void AtWork()
        {
            //todo

            var box = MessageBoxManager.GetMessageBoxStandard("Caption", "AtWork pressed");
            var result = await box.ShowAsync();
        }

        [RelayCommand]
        private async void DayOff()
        {
            //todo

            var box = MessageBoxManager.GetMessageBoxStandard("Caption", "DayOff pressed");
            var result = await box.ShowAsync();
        }

        [RelayCommand]
        private async void Sick()
        {
            //todo

            var box = MessageBoxManager.GetMessageBoxStandard("Caption", "Sick pressed");
            var result = await box.ShowAsync();
        }
    }
}
