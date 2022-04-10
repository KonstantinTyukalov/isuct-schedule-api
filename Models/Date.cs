using Newtonsoft.Json;

namespace Models;

public partial class Date
{
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string Start { get; set; }

    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string End { get; set; }

    [JsonProperty("weekday", NullValueHandling = NullValueHandling.Ignore)]
    public int? Weekday { get; set; }

    [JsonProperty("week", NullValueHandling = NullValueHandling.Ignore)]
    public int? Week { get; set; }
}
