using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RebrickableBrowserApp.DataModels;
public partial class SetPart
{
    [JsonPropertyName("id")]
    public int id { get; set; }
    [JsonPropertyName("inv_part_id")]
    public int inv_part_id { get; set; }
    [JsonPropertyName("part")]
    public Part part { get; set; }
    [JsonPropertyName("color")]
    public PartColor color { get; set; }
    [JsonPropertyName("set_num")]
    public string set_num { get; set; }
    [JsonPropertyName("quantity")]
    public int quantity { get; set; }
    [JsonPropertyName("is_spare")]
    public bool is_spare { get; set; }
    [JsonPropertyName("element_id")]
    public string element_id { get; set; }
    [JsonPropertyName("num_sets")]
    public int num_sets { get; set; }
}
