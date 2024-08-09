using Avalonia.Controls;

namespace MyState.Scenarios.MyStates;

public partial class MyStatesView : UserControl
{
    public MyStatesView()
    {
        InitializeComponent();
        DataContext = new MyStatesViewModel();
    }
}