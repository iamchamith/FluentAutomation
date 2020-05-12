using OpenQA.Selenium;
using Xunit.Abstractions;

namespace FluentAutomation
{
    public class AutomationTestInjector : IAutomationTestInjector
    {
        public AutomationTestInjector(IWebDriver webDriver, ITestOutputHelper testOutputHelper)
        {
            WebDriver = webDriver;
            TestOutputHelper = testOutputHelper;
        }
        public IWebDriver WebDriver { get; set; }
        public ITestOutputHelper TestOutputHelper { get; set; }
    }
}
