using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestAuth3._3.Helpers;

namespace TestAuth3._3;

public class AppManager
{
    private string _baseURL;

    public AppManager()
    {
        _baseURL = "https://www.reddit.com/";
        
        Driver = new FirefoxDriver();
        LoginHelper = new LoginHelper(this);
        NavigationHelper = new NavigationHelper(this, _baseURL);
        PostHelper = new PostHelper(this);
    }

    public void Stop()
    {
        Driver.Quit();
    }
    
    public IWebDriver Driver { get; }

    public NavigationHelper NavigationHelper { get; }

    public LoginHelper LoginHelper { get; }

    public PostHelper PostHelper { get; }
}