using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.DataModels;

public partial class Part
{
    [JsonPropertyName("part_num")]
    public string PartNum { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("part_cat_id")]
    public int PartCatId { get; set; }
    [JsonPropertyName("part_url")]
    public string PartUrl { get; set; }
    [JsonPropertyName("part_img_url")]
    public string PartImgUrl { get; set; }
    [JsonPropertyName("print_of")]
    public string PrintOf { get; set; }
}
