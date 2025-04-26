namespace TestAuth3._3.Tests;

[TestFixture]
public class AuthTest : TestBase
{
    [Test]
    public void Test()
    {
        Manager.NavigationHelper.GoToHomePage();
        Manager.LoginHelper.Login(MockDataDictionary.UserData);
    }
}