namespace TestAuth4._4.Models;

public class PostData
{
    public PostData(string header, string body)
    {
        Header = header;
        Body = body;
    }

    public string Header { get; set; }
    public string Body { get; set; }
}