
namespace TestAuth4._4.Tests;

[TestFixture]
public class AuthTest : TestBase
{
    [Test]
    public void AuthorizationTest()
    {
        Manager.Navigation.GoToHomePage();
        Manager.Login.Login(MockDataDictionary.UserData);
        
        Thread.Sleep(5000);
        Manager.Login.Logout();
        Thread.Sleep(7000);
    }
}