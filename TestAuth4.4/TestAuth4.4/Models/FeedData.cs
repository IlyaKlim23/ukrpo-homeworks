namespace TestAuth4._4.Models;

public class FeedData
{
    public FeedData(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
}