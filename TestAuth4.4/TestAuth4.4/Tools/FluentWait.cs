using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAuth4._4.Tools;

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

    public static void WaitUntilAndDo(IWebDriver webDriver, string script, Action<IWebElement> action)
    {
        var fluentWait = new FluentWait(webDriver);
        fluentWait.WaitUntilAndDoByScript(script, action);
    }

    private void WaitUntilAndDo(By findBy, Action<IWebElement> action)
    {
        _fluentWait.Until(drv =>
        {
            IWebElement? el = null;
            try
            {
                el = drv.FindElement(findBy);
            }
            catch (Exception e)
            { 
                //
            }

            if (el == null)
                return null;
            
            if (el.Displayed)
            {
                action.Invoke(el);
            }

            return el.Displayed ? el : null;
        });
    }
    
    private void WaitUntilAndDoByScript(string script, Action<IWebElement> action)
    {
        bool stop = false;
        try
        {
            _fluentWait.Until(drv =>
            {
                if (stop)
                {
                    throw new OperationCanceledException();
                }
                IWebElement? el = null;
                try
                {
                    el = (IWebElement?)((IJavaScriptExecutor)drv).ExecuteScript(script);
                }
                catch (Exception e)
                { 
                    //
                }

                if (el == null)
                    return null;
            
                if (el.Displayed)
                {
                    action.Invoke(el);
                }
                else
                {
                    stop = true;
                }

                return el.Displayed ? el : null;
            });
        }
        catch (OperationCanceledException e)
        {
            //
        }
    }
}