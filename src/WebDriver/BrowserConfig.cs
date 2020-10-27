using static FluentAutomation.Utility.AutomationEnums;

namespace FluentAutomation.WebDriver
{
    public class BrowserConfig
    {
        public Browser Browser { get; set; }
        public Device Device { get; set; }
        public Resalution Resalution { get; set; }

        public BrowserConfig(Browser browser, Device device, Resalution resalution)
        {
            Browser = browser;
            Device = device;
            Resalution = resalution;
        }
    }
}
