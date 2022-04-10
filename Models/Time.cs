using Newtonsoft.Json;

namespace Models;

public partial class Time
{
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string Start { get; set; }

    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string End { get; set; }
}
