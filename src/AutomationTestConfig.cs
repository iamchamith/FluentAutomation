using static FluentAutomation.AutomationEnums;
namespace FluentAutomation
{
    public class AutomationTestConfig
    {
        public static int Sleep { get; set; } = 3;

        public static string WebDriverLocation = @"C:\webdrivers";
        public static string DbConnectionString { get; private set; }
        public static string Host { get; private set; }
        public static string ApiDomain { get; private set; }
        public static AutomationEnvironment Env { get; set; } = new AutomationEnvironment(new BrowserConfig(AutomationEnums.Browser.Chrome, Device.Laptop, Resalution.None));


        public static void ConfigureConfigs(string host, string api, string connectionstring)
        {
            Host = host;
            ApiDomain = api;
            DbConnectionString = connectionstring;
        }
    }
}
