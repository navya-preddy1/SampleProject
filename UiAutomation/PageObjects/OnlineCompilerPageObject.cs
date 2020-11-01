using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UiAutomation.Utilities;

namespace UiAutomation.PageObjects
{
    public class OnlineCompilerPageObject : BasePageObject
    {
        public OnlineCompilerPageObject(IWebDriver driver) : base(driver)
        {
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "logo navbar-brand")]
        public IWebElement Logo { get; set; }

        [FindsBy(How = How.Id, Using = "run-button")]
        public IWebElement RunButton { get; set; }

        [FindsBy(How = How.Id, Using = "output")]
        public IWebElement OutputSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'sidebar unselectable']")]
        public IWebElement OptionsPanel { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default btn-xs btn-sidebar-toggle']")]
        public IWebElement OptionsToggleButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='glyphicon glyphicon-chevron-right']")]
        public IWebElement OptionsExpander { get; set; }

        public bool PageIsLoaded()
        {
            return Logo.Displayed;
        }

        public void ClickRun()
        {
            RunButton.Click();
        }

        public string GetOutput()
        {
            return OutputSection.Text;
        }

        public void ClickOptionsToggle()
        {
            Helper.waitForElementToBeDisplayed(Driver, OptionsToggleButton);
            OptionsToggleButton.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            wait.Until(d =>
            {
               return OptionsPanel.GetAttribute("style").Contains("-180px;");
            });
        }

        public bool IsOptionsPanelDisplayed()
        {
            return !OptionsPanel.GetAttribute("style").Contains("-180px;");
        }
    }
}
