using TestAuth2._2.Models;

namespace TestAuth3._3;

public static class MockDataDictionary
{
    public static UserData UserData 
        => new UserData("klimkin_ilya2004@mail.ru", "HG2004klmkn");
    
    public static PostData PostData 
        => new PostData("Пример заголовка", "Привет это пример текста");
}