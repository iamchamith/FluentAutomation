using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FluentAutomation.Utility
{
    public static class CommonExtensions
    {
        public static string TrimAndToLower(this string value)
        {
            return (value ?? "").Trim().ToLower();
        }
        public static bool IsNull(this object value)
        {
            return value == null;
        }
        public static bool Is(this string value, string complareWith)
        {
            return value == complareWith;
        }
        public static bool Is(this int value, int complareWith)
        {
            return value == complareWith;
        }
        public static string GetDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }
    }
}
