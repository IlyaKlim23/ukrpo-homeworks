using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestAuth2._2.Models;
using TestAuth3._3.Tools;

namespace TestAuth3._3.Helpers;

public class LoginHelper(AppManager manager) : HelperBase(manager)
{
    public void Login(UserData userData)
    {
        manager.Driver.FindElement(By.CssSelector("#login-button > .flex > .flex")).Click();
        {
            var element = manager.Driver.FindElement(By.Id("login-button"));
            var builder = new Actions(manager.Driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = manager.Driver.FindElement(By.CssSelector(".mr-md:nth-child(3) .h-\\[185px\\]"));
            var builder = new Actions(manager.Driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = manager.Driver.FindElement(By.TagName("body"));
            var builder = new Actions(manager.Driver);
            builder.MoveToElement(element, 0, 0).Perform();
        }
        var loginElement = manager.Driver.FindElement(By.Id("login-username"));
        loginElement.Click();
        _jsExecutor.InsertValue(loginElement, userData.Email);
        
        var passwordElement = manager.Driver.FindElement(By.Id("login-password"));
        passwordElement.Click();
        _jsExecutor.InsertValue(passwordElement, userData.Password);

        new Actions(manager.Driver).SendKeys(Keys.Enter).Perform();
    }
}