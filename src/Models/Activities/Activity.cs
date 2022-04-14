namespace Models.Activities;

public class Activity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public ActivityTime Time { get; set; }
}
