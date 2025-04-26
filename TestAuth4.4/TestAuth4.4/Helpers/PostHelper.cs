using OpenQA.Selenium;
using TestAuth4._4.Tools;
using TestAuth4._4.Models;

namespace TestAuth4._4.Helpers;

public class PostHelper(AppManager manager) : HelperBase(manager)
{
    public void CreatePost(PostData data)
    {
        FluentWait.WaitUntilAndDo(_manager.Driver, By.CssSelector(@".rounded-\[20px\]"), x =>
        {
            x.Click();
            _jsExecutor.InsertValue(x, data.Header);
        });
        
        var textElement = _manager.Driver.FindElement(By.CssSelector(".resize-y"));
        textElement.Clear();
        data.Body.ToList().ForEach(x => textElement.SendKeys(x.ToString()));
        Thread.Sleep(500);
        
        _manager.Driver.FindElement(By.Id("save-draft-button")).Click();
        
        Thread.Sleep(2000);
    }

    public PostData GetCreatedPostData()
    {
        var header = _jsExecutor.GetValue(_manager.Driver.FindElement(By.CssSelector(@".rounded-\[20px\]"))) 
            ?? string.Empty;  
        var text = _manager.Driver.FindElement(By.CssSelector(".resize-y")).Text;  

        return new PostData(header, text);
    }
}