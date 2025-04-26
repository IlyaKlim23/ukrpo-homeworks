namespace TestAuth3._3.Tests;

public class TestBase
{
    protected AppManager Manager;

    [SetUp]
    public void SetUp()
    {
        Manager = new AppManager();
    }

    [TearDown]
    protected void TearDown()
    {
        Manager.Stop();
    }

}