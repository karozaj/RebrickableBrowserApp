using Microsoft.UI.Xaml.Media.Imaging;
using RebrickableBrowserApp.DataModels;
using Uno.Extensions.Navigation;
namespace RebrickableBrowserApp;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SetDetailsPage : Page
{
    public SetDetailsPage()
    {
        this.InitializeComponent();
        SetDetailsVM.UpdateSetInfo();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        SetDetailsVM.SetSetInfo(e.Parameter as Set);
        base.OnNavigatedTo(e);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        button.Visibility = Visibility.Collapsed;
        SetDetailsVM.SearchForParts();
        PartsListView.Visibility = Visibility.Visible;
    }
}
