namespace TestAuth4._4.Tests;

[TestFixture]
public class CreateFeedTest : TestBase
{
    [Test]
    public void FeedTest()
    {
        Manager.Navigation.GoToHomePage();
        Manager.Login.Login(MockDataDictionary.UserData);
        Manager.Feed.CreateFeed(MockDataDictionary.FeedData);
        
        Thread.Sleep(3000);
        
        var data = Manager.Feed.GetFeedData();
        
        Assert.Multiple(() =>
        {
            Assert.That(data.Name, Is.EqualTo(MockDataDictionary.FeedData.Name));
            Assert.That(data.Description, Is.EqualTo(MockDataDictionary.FeedData.Description));
        });
        
        Manager.Feed.DeleteFeed();
        
        Thread.Sleep(1000);
        
        Manager.Login.Logout();
        
        Thread.Sleep(3000);
    }
}