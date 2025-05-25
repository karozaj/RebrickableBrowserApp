using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RebrickableBrowserApp.DataModels;

namespace RebrickableBrowserApp.WebServices;
internal class SetPartsSearchApi:WebApiBase
{
    public async Task<IEnumerable<SetPart>> Search(string search)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"Searching for parts with term: {search}");
            var result = await this.GetAsync(
                $"https://rebrickable.com/api/v3/lego/sets/{WebUtility.HtmlEncode(search.ToString())}/parts/",
                ApiSettings.GetDefaultHeaders());

            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine($"Search result: {result}");
                SetPartsSearchResponse partSearchResult = JsonSerializer.Deserialize<SetPartsSearchResponse>(result);
                if (partSearchResult.Results != null && partSearchResult.Count > 0)
                {
                    return partSearchResult.Results;
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            System.Diagnostics.Debug.WriteLine($"Exception during search: {ex.Message}");
        }

        return new List<SetPart>();
    }
}
