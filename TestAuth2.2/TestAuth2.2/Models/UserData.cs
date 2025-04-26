namespace TestAuth2._2.Models;

public class UserData
{
    public UserData(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    
    public string Password { get; set; }
}