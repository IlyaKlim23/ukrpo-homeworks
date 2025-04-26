using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestAuth4._4.Helpers;

namespace TestAuth4._4;

public class AppManager
{
    private AppManager()
    {
        var baseUrl = "https://www.reddit.com/";
        
        Driver = new FirefoxDriver();
        Login = new LoginHelper(this);
        Navigation = new NavigationHelper(this, baseUrl);
        Post = new PostHelper(this);
        Feed = new FeedHelper(this);
    }
    
    public void Stop()
    {
        Driver.Quit();
    }
    
    public IWebDriver Driver { get; }

    public NavigationHelper Navigation { get; }

    public LoginHelper Login { get; }

    public PostHelper Post { get; }
    
    public FeedHelper Feed { get; }
    
    ~AppManager()
    {
        try
        {
            Stop();
        }
        catch (Exception)
        { 
            //ignore
        }
    }
    
    public static AppManager GetInstance()  
    {
        if (App.IsValueCreated) return App.Value!;
        var newInstance = new AppManager();  
        newInstance.Navigation.GoToHomePage();  
        App.Value = newInstance;

        return App.Value!;  
    }  
    
    private static readonly ThreadLocal<AppManager> App = new ();
}