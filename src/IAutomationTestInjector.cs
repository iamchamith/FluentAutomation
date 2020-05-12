using OpenQA.Selenium;
using Xunit.Abstractions;

namespace FluentAutomation
{
    public interface IAutomationTestInjector
    {
        IWebDriver WebDriver { get; set; }
        ITestOutputHelper TestOutputHelper { get; set; }
    }
}
