using Newtonsoft.Json;

namespace Models;

public partial class Audience
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
}
