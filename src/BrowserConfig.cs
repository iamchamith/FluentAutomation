using static FluentAutomation.AutomationEnums;

namespace FluentAutomation
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
