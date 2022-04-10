using Newtonsoft.Json;

namespace Models;

public partial class Teacher
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
}
