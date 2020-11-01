
using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UiAutomation.Utilities
{
    public static class Helper
    {
        public static void waitForElementToBeDisplayed(IWebDriver driver, IWebElement element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(d =>
            {
                try
                {
                    return element != null;
                }
                catch (Exception e) when (e is NoSuchElementException || e is TargetInvocationException)
                {
                    return false;
                }
            });
        }
    }
}
