using Avalonia.Controls;

namespace MyState.Scenarios.TeamStates;

public partial class TeamStatesView : UserControl
{
    public TeamStatesView()
    {
        InitializeComponent();
        DataContext = new TeamStatesViewModel();
    }
}