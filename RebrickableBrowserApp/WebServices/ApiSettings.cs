using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.WebServices;
public class ApiSettings
{
    public static string ApiKey="";
    public static Dictionary<string,string> GetDefaultHeaders()
    {
        return new Dictionary<string, string>
        {
            {"Accept", "application/json" },
            {"Authorization", $"key {ApiKey}"}
        };
    }
}
