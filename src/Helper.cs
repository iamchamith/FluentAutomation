using OpenQA.Selenium;
using System;
using System.Text;

namespace FluentAutomation
{
    public class Helper
    {
        public const string ClearBrowserLocalStorageScript = "window.localStorage.clear();";

        public static void RunJs(IWebDriver webDriver, string script)
        {
            var js = webDriver as IJavaScriptExecutor;
            js.ExecuteScript(script);
        }

        public static string GetRandomNumber(int length)
        {
            var number = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                number.Append(rd.Next(0, 9));
            }

            return number.ToString();
        }

        public static string GetRandomName(int length)
        {
            var name = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                name.Append(rd.Next('a', 'z'));
            }

            return name.ToString();
        }

        public static string ConvertToJsInput(string date)
        {
            string result = "";
            var arr = date.Split("/");
            result += arr[2] + '-';
            if (arr[0].Length == 1)
            {
                result += '0' + arr[0] + '-';
            }
            else
            {
                result += arr[0] + '-';
            }

            if (arr[1].Length == 1)
            {
                result += '0' + arr[1];
            }
            else
            {
                result += arr[1];
            }

            return result;
        }

        public static void ClickConfirmYes(IWebDriver driver) {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
