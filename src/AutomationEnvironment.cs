namespace FluentAutomation
{
    public class AutomationEnvironment
    {
        public BrowserConfig BrowserConfig { get; set; }

        public AutomationEnvironment(BrowserConfig browserConfig)
        {
            BrowserConfig = browserConfig;
        }
    }
}
