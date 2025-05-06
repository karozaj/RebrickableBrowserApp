using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Imaging;
using RebrickableBrowserApp.DataModels;
using RebrickableBrowserApp.ViewModels;
using Uno.Extensions.Navigation;
namespace RebrickableBrowserApp;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private async void SetSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        try
        {
            await ViewModel.SearchForSets();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            System.Diagnostics.Debug.WriteLine($"Exception during search: {ex.Message}");
        }
    }

    private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        ((Image)sender).Source = new BitmapImage(new Uri("/Assets/default.png", UriKind.Relative));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            Set set = button.DataContext as Set;
            if(set!=null)
            {
                SetDetailsViewModel.currentSet = set;
                Frame.Navigate(typeof(SetDetailsPage), set);
            }
        }
    }

}
