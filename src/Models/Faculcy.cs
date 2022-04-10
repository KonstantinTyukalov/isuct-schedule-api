using Newtonsoft.Json;

namespace Models;

public partial class Faculty
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
    public List<Group> Groups { get; set; }
}
