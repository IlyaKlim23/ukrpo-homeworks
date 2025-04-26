namespace TestAuth4._4.Tests;

public class TestBase
{
    protected AppManager Manager;

    [SetUp]
    public void SetUp()
    {
        Manager = AppManager.GetInstance();  
    }
}