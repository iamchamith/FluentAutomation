using System;
using System.Collections.Generic;
using static FluentAutomation.AutomationEnums;

namespace FluentAutomation
{
    public class AutomationTestConfig
    {
        public static Dictionary<string, object> SharedData { get; set; } = new Dictionary<string, object>();
        public static int Sleep { get; set; } = 3;

        public static string WebDriverLocation = @"C:\webdrivers";

        public static string DbConnectionString = "Server=52.148.93.180; Port=3306; Database=expresslk_qa; Uid=bbk; Pwd=hard2crack2009$;SslMode=none;SslMode=Preferred;";
        public static string Host { get; set; } = "http://gardaeialtd.test.assocify.io/#/login";

        public static string ApiDomain { get; set; } = "https://test-api.express.lk/";
        public static AutomationEnvironment Env { get; set; } = new AutomationEnvironment(new BrowserConfig(AutomationEnums.Browser.Chrome, Device.Laptop, Resalution.None));
    }
}
