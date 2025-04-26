using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using TestAuth2._2.Models;
using TestAuth3._3.Helpers;

namespace TestAuth3._3;

public class TestBase
{
    private IWebDriver _driver;
    private JSExecutor _jsExecutor;

    [SetUp]
    public void SetUp()
    {
        _driver = new FirefoxDriver();
        _jsExecutor = new JSExecutor(_driver);
    }

    [TearDown]
    protected void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    protected void OpenHomePage()
    {
        _driver.Navigate().GoToUrl("https://www.reddit.com/");

        var googleForm = _driver.FindElement(By.Id("credential_picker_container"));
        _jsExecutor.RemoveElement(googleForm);
    }
    
    protected void Login(UserData userData)
    {
        _driver.FindElement(By.CssSelector("#login-button > .flex > .flex")).Click();
        {
            var element = _driver.FindElement(By.Id("login-button"));
            var builder = new Actions(_driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = _driver.FindElement(By.CssSelector(".mr-md:nth-child(3) .h-\\[185px\\]"));
            var builder = new Actions(_driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = _driver.FindElement(By.TagName("body"));
            var builder = new Actions(_driver);
            builder.MoveToElement(element, 0, 0).Perform();
        }
        var loginElement = _driver.FindElement(By.Id("login-username"));
        loginElement.Click();
        _jsExecutor.InsertValue(loginElement, userData.Email);
        
        var passwordElement = _driver.FindElement(By.Id("login-password"));
        passwordElement.Click();
        _jsExecutor.InsertValue(passwordElement, userData.Password);

        new Actions(_driver).SendKeys(Keys.Enter).Perform();
    }

    protected void CreateDraft(PostData data)
    {
        FluentWait.WaitUntilAndDo(_driver, By.Id("create-post"), x =>
        {
            x.Click();
        });
        
        FluentWait.WaitUntilAndDo(_driver, By.CssSelector(@".rounded-\[20px\]"), x =>
        {
            x.Click();
            _jsExecutor.InsertValue(x, data.Header);
        });
        
        var textElement = _driver.FindElement(By.CssSelector(".resize-y"));
        textElement.Clear();
        data.Body.ToList().ForEach(x => textElement.SendKeys(x.ToString()));
        Thread.Sleep(500);
        
        _driver.FindElement(By.Id("save-draft-button")).Click();
        
        Thread.Sleep(2000);
    }
}