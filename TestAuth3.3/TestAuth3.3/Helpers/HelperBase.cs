using OpenQA.Selenium;
using TestAuth3._3.Tools;

namespace TestAuth3._3.Helpers;

public class HelperBase
{
    protected AppManager _manager;
    protected JsExecutor _jsExecutor;
    
    public HelperBase(AppManager manager)
    {
        _manager = manager;
        _jsExecutor = new JsExecutor(_manager.Driver);
    }
}