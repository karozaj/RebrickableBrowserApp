using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RebrickableBrowserApp.DataModels;
using RebrickableBrowserApp.WebServices;

namespace RebrickableBrowserApp.ViewModels;
public class MainViewModel : DispatchedBindableBase
{
    // Insert member variables below here
    private bool _isBusy;
    private string _searchTerm = string.Empty;
    private static ObservableCollection<Set> _searchResults = new ObservableCollection<Set>();
    private SetSearchApi _setSearchApi = new SetSearchApi();
    // Insert properties below here
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public string SearchTerm
    {
        get => _searchTerm;
        set => SetProperty(ref _searchTerm, value);
    }

    public ObservableCollection<Set> SearchResults
    {
        get => _searchResults;
        set => SetProperty(ref _searchResults, value);
    }


    public async Task SearchForSets()
    {
        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            try
            {
                IsBusy = true;
                var result = await _setSearchApi.Search(SearchTerm).ConfigureAwait(false);
                if (result.Any())
                {
                    SearchResults = new ObservableCollection<Set>(result);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

        
}
