using Microsoft.UI.Xaml.Media.Imaging;

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

    private void SearchResults_ItemClick(object sender, ItemClickEventArgs e)
    {

    }

    private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        ((Image)sender).Source = new BitmapImage(new Uri("/Assets/default.png", UriKind.Relative));
    }
}
