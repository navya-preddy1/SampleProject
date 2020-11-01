using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UiAutomation.PageObjects;
using UiTest.Utilities;

namespace UiTest.TestScripts
{
    [TestClass]
    public class OnlineCompilerTests : BaseTest
    {
        private OnlineCompilerPageObject onlineCompilerPage;

        public OnlineCompilerTests() { }
        public OnlineCompilerTests(IWebDriver driver)
        {
            Driver = driver;
        }

        [TestInitialize]
        public void Setup()
        {
            SetupTest();
            onlineCompilerPage = new OnlineCompilerPageObject(Driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            FinalizeTest();
        }

        [TestMethod]
        [Description("Test 1 - .NetFiddle Run Program Test")]
        public void DotNetFiddleRunProgramTest()
        {
            onlineCompilerPage.ClickRun();
            Assert.AreEqual(onlineCompilerPage.GetOutput(), "Hello World", "Verify 'Hello World' is printed");
        }

        [TestMethod]
        [Description("Test 2 - Options Panel Toggle Test")]
        public void OptionsPanelToggleTest()
        {
            onlineCompilerPage.ClickOptionsToggle();
            Assert.IsFalse(onlineCompilerPage.IsOptionsPanelDisplayed(), "Verify Options Panel is hidden");
        }
    }
}
