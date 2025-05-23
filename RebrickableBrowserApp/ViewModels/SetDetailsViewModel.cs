using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RebrickableBrowserApp.DataModels;
using RebrickableBrowserApp.WebServices;

namespace RebrickableBrowserApp.ViewModels;
internal class SetDetailsViewModel : DispatchedBindableBase
{
    private bool _isBusy;
    private static ObservableCollection<SetPart> _partsList = new ObservableCollection<SetPart>();
    private string _setNumber=String.Empty;
    private string _name = String.Empty;
    private int _year=0;
    private int _numParts=0;
    private string _setImgUrl = String.Empty;
    private string _headerText = "Parts list:";
    private  SetPartsSearchApi _searchApi=new SetPartsSearchApi();

    public static Set currentSet;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public ObservableCollection<SetPart> PartsList
    {
        get => _partsList;
        set => SetProperty(ref _partsList, value);
    }

    public string HeaderText
    {
        get => _headerText;
        set => SetProperty(ref _headerText, value);
    }

    public string SetNumber
    {
        get => _setNumber;
        set => SetProperty(ref _setNumber, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public int Year
    {
        get => _year;
        set => SetProperty(ref _year, value);
    }

    public int NumParts
    {
        get => _numParts;
        set => SetProperty(ref _numParts, value);
    }

    public string SetImgUrl
    {
        get => _setImgUrl;
        set => SetProperty(ref _setImgUrl, value);
    }

    public void UpdateSetInfo()
    {
        if (currentSet == null) { return; }
        Name = currentSet.Name;
        SetNumber = currentSet.SetNumber;
        Year = currentSet.Year;
        NumParts = currentSet.NumParts;
        SetImgUrl = currentSet.SetImgUrl;
    }

    public void SetSetInfo(Set set)
    {
        currentSet = set;
        Name=set.Name;
        SetNumber = set.SetNumber;
        Year=set.Year;
        NumParts=set.NumParts;
        SetImgUrl=set.SetImgUrl;
    }


    public async Task SearchForParts()
    {
        PartsList.Clear();
        if (!string.IsNullOrWhiteSpace(SetNumber))
        {
            try
            {
                IsBusy = true;
                var result = await _searchApi.Search(SetNumber).ConfigureAwait(false);
                if (result.Any())
                {
                    PartsList = new ObservableCollection<SetPart>(result);
                }
                else
                {
                    HeaderText = "No parts detected!";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
