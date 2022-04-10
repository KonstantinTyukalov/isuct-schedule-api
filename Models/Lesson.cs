using Newtonsoft.Json;

namespace Models;

public partial class Lesson
{
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public string Subject { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
    public Time Time { get; set; }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public Date Date { get; set; }

    [JsonProperty("audiences", NullValueHandling = NullValueHandling.Ignore)]
    public List<Audience> Audiences { get; set; }

    [JsonProperty("teachers", NullValueHandling = NullValueHandling.Ignore)]
    public List<Teacher> Teachers { get; set; }
}
