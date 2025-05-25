using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.DataModels;
public partial class PartColor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("rgb")]
    public string Rgb { get; set; }
    [JsonPropertyName("is_trans")]
    public bool IsTrans { get; set; }
}
