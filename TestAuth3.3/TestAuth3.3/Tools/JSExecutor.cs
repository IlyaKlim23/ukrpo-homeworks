﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace TestAuth3._3.Tools;

public class JsExecutor
{
    private readonly IWebDriver _driver;
    public JsExecutor(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void RemoveElement(IWebElement element)
        => _driver.ExecuteJavaScript("arguments[0].remove();", element);

    public void InsertValue(IWebElement element, string value)
        => _driver.ExecuteJavaScript($"arguments[0].value = '{value}';", element);
}