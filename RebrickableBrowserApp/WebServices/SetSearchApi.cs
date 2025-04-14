using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RebrickableBrowserApp.DataModels;

namespace RebrickableBrowserApp.WebServices;
public class SetSearchApi:WebApiBase
{
    const int SEARCH_RESULT_MAX_SIZE = 50;
    public async Task<IEnumerable<Set>> Search(string search)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"Searching for sets with term: {search}");
            var result = await this.GetAsync(
                $"https://rebrickable.com/api/v3/lego/sets/?page=1&page_size={WebUtility.HtmlEncode(SEARCH_RESULT_MAX_SIZE.ToString())}" +
                $"&search={WebUtility.HtmlEncode(search)}",
                ApiSettings.GetDefaultHeaders());

            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine($"Search result: {result}");
                SetSearchResponse setSearchResult = JsonSerializer.Deserialize<SetSearchResponse>(result);
                if (setSearchResult.Results != null && setSearchResult.Count > 0)
                {
                    return setSearchResult.Results;
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            System.Diagnostics.Debug.WriteLine($"Exception during search: {ex.Message}");
        }

        return new List<Set>();
    }
}

