namespace TestAuth4._4.Models;

public class UserData
{
    public UserData(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }

    public string UserName { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
}