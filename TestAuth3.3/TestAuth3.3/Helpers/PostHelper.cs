using OpenQA.Selenium;
using TestAuth2._2.Models;
using TestAuth3._3.Tools;

namespace TestAuth3._3.Helpers;

public class PostHelper(AppManager manager) : HelperBase(manager)
{
    public void CreatePost(PostData data)
    {
        FluentWait.WaitUntilAndDo(manager.Driver, By.CssSelector(@".rounded-\[20px\]"), x =>
        {
            x.Click();
            _jsExecutor.InsertValue(x, data.Header);
        });
        
        var textElement = manager.Driver.FindElement(By.CssSelector(".resize-y"));
        textElement.Clear();
        data.Body.ToList().ForEach(x => textElement.SendKeys(x.ToString()));
        Thread.Sleep(500);
        
        manager.Driver.FindElement(By.Id("save-draft-button")).Click();
        
        Thread.Sleep(2000);
    }
}