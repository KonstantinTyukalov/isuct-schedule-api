using Newtonsoft.Json;

namespace Models;

public class Schedule
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("abbr", NullValueHandling = NullValueHandling.Ignore)]
    public string Abbr { get; set; }

    [JsonProperty("faculties", NullValueHandling = NullValueHandling.Ignore)]
    public List<Faculty> Faculties { get; set; }
}
