using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FluentAutomation
{
    public static class ElementExtensions
    {
        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By elementLocator, int timeout = 50)
        {
            try
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until(ExpectedConditions.ElementExists(elementLocator));
                var actions = new Actions(driver);
                try
                {
                    actions.MoveToElement(element);
                    actions.Perform();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return element;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static IWebElement WaitUntilElementExistsLoop(this IWebDriver driver, By elementLocator, int timeout = 50)
        {
            while (true)
            {
                try
                {
                    return WaitUntilElementExists(driver, elementLocator, timeout);
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
        }
        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = 50)
        {
            try
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                var actions = new Actions(driver);
                try
                {
                    actions.MoveToElement(element);
                    actions.Perform();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return element;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }



        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string InnerHtml(this IWebElement element, IWebDriver driver)
        {
            bool staleElement = true;
            var innerHtml = string.Empty;
            var index = 0;
            while (staleElement)
            {
                if (index > 10)
                    break;
                try
                {
                    var js = driver as IJavaScriptExecutor;
                    innerHtml = (string)js.ExecuteScript("return arguments[0].innerHTML;", element);
                    return innerHtml;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    Thread.Sleep(500);
                }
                index++;
            }
            return innerHtml;
        }

        public static IWebElement ExecuteJs(this IWebElement element, IWebDriver driver, string script)
        {
            bool staleElement = true;
            var index = 0;
            while (staleElement)
            {
                if (index > 10)
                    break;
                try
                {
                    var js = driver as IJavaScriptExecutor;
                    js.ExecuteScript(script, element);
                    return element;

                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    Thread.Sleep(500);
                }
                index++;
            }
            return element;
        }
    }
}
