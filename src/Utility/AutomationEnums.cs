using System.ComponentModel;

namespace FluentAutomation.Utility
{
    public class AutomationEnums
    {
        public enum Browser
        {
            Chrome,
            Firefox,
            Edge,
            IE,
            Safari
        }
        public enum WebDriverIdentifyBy
        {
            XPath,
            Id,
            ClassName,
            CssSelector
        }
        public enum Device
        {
            Laptop,
            [Description("iPhone X")]
            IPhoneX
        }
        public enum Resalution
        {
            None,
        }
        public enum Crud
        {
            Select,
            Create,
            Update,
            Delete
        }
        public enum HttpRouteType
        {
            Get, Post, Put, Delete
        }
    }
}
