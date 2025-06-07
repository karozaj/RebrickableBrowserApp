using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.DataModels;
public partial class Minifigure
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("set_num")]
    public string SetNumber { get; set; }
    [JsonPropertyName("set_name")]
    public string SetName { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("set_img_url")]
    public string SetImgUrl { get; set; }
}
