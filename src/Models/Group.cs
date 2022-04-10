using Newtonsoft.Json;

namespace Models;

public partial class Group
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("lessons", NullValueHandling = NullValueHandling.Ignore)]
    public List<Lesson> Lessons { get; set; }
}