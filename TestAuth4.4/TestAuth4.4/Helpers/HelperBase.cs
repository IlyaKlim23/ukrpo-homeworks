using TestAuth4._4.Tools;

namespace TestAuth4._4.Helpers;

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