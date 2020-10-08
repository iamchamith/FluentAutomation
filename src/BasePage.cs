using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit.Abstractions;

namespace FluentAutomation
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected Random _random;
        protected ITestOutputHelper _writer;
        protected IAutomationTestInjector _automationTestInjector;
        public BasePage(IAutomationTestInjector automationTestInjector)
        {
            _driver = automationTestInjector.WebDriver;
            _driver.Manage().Window.Maximize();
            _writer = automationTestInjector.TestOutputHelper;
            _random = new Random();
            _automationTestInjector = automationTestInjector;
        }

        protected void Sleep()
        {
            Sleep(AutomationTestConfig.Sleep);
        }
        protected void Sleep(int sec)
        {
            Thread.Sleep(sec * 1000);
        }
        protected void StartWith(string item1, string item2)
        {
            if (!(item1.StartsWith(item2) || item2.StartsWith(item1)))
                _writer.WriteLine($"[X] :- {item1} not start with {item2}.");
        }

        protected void Equal(string item1, string item2)
        {
            if (!item1.Is(item2))
                _writer.WriteLine($"[X] :- {item1} != {item2}.");
        }

        protected void ContentOrEqual(string item1, string item2)
        {
            item1 = item1.TrimAndToLower();
            item2 = item2.TrimAndToLower();
            if (!(item1.Contains(item2) || item2.Contains(item1)))
                _writer.WriteLine($"[X] :- {item1} != {item2}.");
        }

        protected void Log(Exception ex)
        {
            _writer.WriteLine($"[X] :- {ex.StackTrace}.");
        }
        protected void NotNull<T>(T item)
        {
            if (!item.IsNull())
                _writer.WriteLine($"[X] :- Item is null.");
        }

        protected void True(bool t)
        {
            if (!t)
                _writer.WriteLine($"[X] :- Need true.");
        }

        protected void GoTo(string relatedUrl)
        {
            _driver.Navigate().GoToUrl($"{AutomationTestConfig.Host}{relatedUrl}");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual void Logout()
        {
            Helper.RunJs(_driver, Helper.ClearBrowserLocalStorageScript);
        }

        public void AssertInnerHtml(string id,string compareValue)
        {
            string.Equals(_driver.WaitUntilElementExists(By.Id(id))
                 .GetInnerHtmlValue(_driver), compareValue, StringComparison.InvariantCultureIgnoreCase);

        }
    }
}
