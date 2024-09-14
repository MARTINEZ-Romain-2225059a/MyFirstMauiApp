using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace MyFirstMauiApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string text;
    }
}
