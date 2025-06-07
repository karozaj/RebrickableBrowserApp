using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RebrickableBrowserApp.DataModels;

namespace RebrickableBrowserApp.WebServices;
internal class SetMinifiguresSearchApi:WebApiBase
{
    public async Task<IEnumerable<Minifigure>> Search(string search)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"Searching for minifigures with term: {search}");
            var result = await this.GetAsync(
                $"https://rebrickable.com/api/v3/lego/sets/{WebUtility.HtmlEncode(search.ToString())}/minifigs/",
                ApiSettings.GetDefaultHeaders());

            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine($"Search result: {result}");
                SetMinifiguresSearchResponse minifigSearchResult = JsonSerializer.Deserialize<SetMinifiguresSearchResponse>(result);
                if (minifigSearchResult.Results != null && minifigSearchResult.Count > 0)
                {
                    return minifigSearchResult.Results;
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            System.Diagnostics.Debug.WriteLine($"Exception during search: {ex.Message}");
        }

        return new List<Minifigure>();
    }
}
