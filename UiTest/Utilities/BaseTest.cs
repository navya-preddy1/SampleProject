using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTest.Utilities
{
    [TestClass]
    public class BaseTest
    {
        public static IWebDriver Driver { get; set; }

        public BaseTest()
        {

        }

        public void SetupTest()
        {
            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--start-maximized");
            Driver = new ChromeDriver(driverOptions);
        }

        public void FinalizeTest()
        {
            Driver.Close();
            Driver.Quit();
        }

        
    }
}
