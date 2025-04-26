namespace TestAuth4._4.Tests;

[TestFixture]
public class CreateDraftTest : TestBase
{
    [Test]
    public void DraftTest()
    {
        Manager.Navigation.GoToHomePage();
        Manager.Login.Login(MockDataDictionary.UserData);
        Manager.Navigation.GoToCreatePostPage();
        Manager.Post.CreatePost(MockDataDictionary.PostData);

        var createdPostData = Manager.Post.GetCreatedPostData();
        
        Assert.Multiple(() =>
        {
            Assert.That(createdPostData.Header, Is.EqualTo(MockDataDictionary.PostData.Header));
            Assert.That(createdPostData.Body, Is.EqualTo(MockDataDictionary.PostData.Body));
        });
        
        Manager.Login.Logout();
        
        Thread.Sleep(5000);
    }
}