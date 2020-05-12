using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace FluentAutomation
{
    public class WebDriverFactory
    {
        public IWebDriver GetWebDriver(BrowserConfig cnf)
        {
            switch (cnf.Browser)
            {
                case AutomationEnums.Browser.Chrome:
                    if (cnf.Device != AutomationEnums.Device.Laptop)
                    {
                        return Chrome(cnf);
                    }
                    else
                    {
                        return Chrome();
                    }
                    break;
                case AutomationEnums.Browser.Firefox:
                    return FireFox();
                case AutomationEnums.Browser.Edge:
                    return Edge();
                case AutomationEnums.Browser.IE:
                    return IE();
                case AutomationEnums.Browser.Safari:
                    break;
            }
            throw new ArgumentException("Cannot find praticular web driver settings");
        }

        private IWebDriver Chrome()
        {
            return new ChromeDriver(AutomationTestConfig.WebDriverLocation);
        }

        private IWebDriver Chrome(BrowserConfig cnf)
        {
            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(AutomationTestConfig.WebDriverLocation);
            chromeService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();

            //var mobileEmulationSettings = new ChromeMobileEmulationDeviceSettings
            //{
            //    UserAgent = emulatorSettings.DeviceUserAgent,
            //    Width = emulatorSettings.DeviceWidth,
            //    Height = emulatorSettings.DeviceHeight,
            //    EnableTouchEvents = true,
            //    PixelRatio = emulatorSettings.DevicePixelRatio
            //};
            options.EnableMobileEmulation($"{cnf.Device.GetDescription()}");
            return new ChromeDriver(chromeService, options);
        }

        IWebDriver FireFox()
        {
            var service = FirefoxDriverService.CreateDefaultService(AutomationTestConfig.WebDriverLocation);
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            return new FirefoxDriver(service);
        }
        IWebDriver Edge()
        {
            //https://docs.microsoft.com/en-us/microsoft-edge/webdriver-chromium
            // Change msedgedriver to MicrosoftWebDriver
            var service = EdgeDriverService.CreateDefaultService(AutomationTestConfig.WebDriverLocation);
            service.UseVerboseLogging = true;
            service.UseSpecCompliantProtocol = true;
            service.Start();
            //var caps = new DesiredCapabilities(new Dictionary<string, object>()
            //    {
            //        { "ms:edgeOptions", new Dictionary<string, object>() {
            //            {  "binary", @"C:\Program Files (x86)\Microsoft\Edge Dev\Application\msedge.exe" }
            //        }}
            //});
            service.HideCommandPromptWindow = true;
            service.Start();

            var options = new EdgeOptions();
            return new EdgeDriver(service, options);
        }

        IWebDriver IE()
        {
            InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService(AutomationTestConfig.WebDriverLocation);
            ieService.HideCommandPromptWindow = true;
            ieService.Start();

            var ieOptions = new InternetExplorerOptions();

            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = false;

            return new InternetExplorerDriver(ieService, ieOptions);
        }
        IWebDriver Safari()
        {
            return null;
        }
    }
}
