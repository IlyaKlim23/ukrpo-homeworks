using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAuth3._3.Tools;

public class FluentWait
{
    private DefaultWait<IWebDriver> _fluentWait;
    
    private FluentWait(IWebDriver webDriver)
    {
        _fluentWait = new DefaultWait<IWebDriver>(webDriver)
        {
            Timeout = TimeSpan.FromSeconds(30),
            PollingInterval = TimeSpan.FromMilliseconds(1000),
            Message = "Элемент не найден за указанное время"
        };
        
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public static void WaitUntilAndDo(IWebDriver webDriver, By findBy, Action<IWebElement> action)
    {
        var fluentWait = new FluentWait(webDriver);
        fluentWait.WaitUntilAndDo(findBy, action);
    }

    private void WaitUntilAndDo(By findBy, Action<IWebElement> action)
    {
        _fluentWait.Until(drv =>
        {
            var el = drv.FindElement(findBy);

            if (el.Displayed)
            {
                action.Invoke(el);
            }
            
            return el.Displayed ? el : null;
        });
    }
}