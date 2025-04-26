namespace TestAuth3._3.Tests;

[TestFixture]
public class CreateDraftTest : TestBase
{
    [Test]
    public void Test()
    {
        Manager.NavigationHelper.GoToHomePage();
        Manager.LoginHelper.Login(MockDataDictionary.UserData);
        Manager.NavigationHelper.GoToCreatePostPage();
        Manager.PostHelper.CreatePost(MockDataDictionary.PostData);
    }
}