using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyFirstMauiApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;  
        public MainViewModel(IConnectivity connectivity)
        {
            Items = [];
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error", "No Internet", "OK");
                return;
            }

            Items.Add(Text);

            //add our item
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            Items.Remove(s);

        }

        //Permet de changer de page vers DetailPage
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }

    }
}
