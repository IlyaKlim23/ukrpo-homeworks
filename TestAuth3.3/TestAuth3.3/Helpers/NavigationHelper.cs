using OpenQA.Selenium;
using TestAuth3._3.Tools;

namespace TestAuth3._3.Helpers;

public class NavigationHelper(AppManager manager, string url) : HelperBase(manager)
{
    public void GoToHomePage()
    {
        manager.Driver.Navigate().GoToUrl(url);

        var googleForm = manager.Driver.FindElement(By.Id("credential_picker_container"));
        _jsExecutor.RemoveElement(googleForm);
    }

    public void GoToCreatePostPage()
        => FluentWait.WaitUntilAndDo(manager.Driver, By.Id("create-post"), x => x.Click());
}