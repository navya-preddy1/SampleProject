
using OpenQA.Selenium;

namespace UiAutomation.Utilities
{
    public class BasePageObject
    {
        public IWebDriver Driver { get; set; }
        public BasePageObject(IWebDriver driver)
        {
            Driver = driver;

        }
    }
}
