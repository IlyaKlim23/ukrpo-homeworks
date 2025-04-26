using TestAuth4._4.Models;

namespace TestAuth4._4;

public static class MockDataDictionary
{
    public static UserData UserData 
        => new ("ilklmkn23", "klimkin_ilya2004@mail.ru", "HG2004klmkn");
    
    public static PostData PostData 
        => new ("Пример заголовка", "Привет это пример текста");
    
    public static FeedData FeedData 
        => new ("FeedName", "FeedDescription");
}