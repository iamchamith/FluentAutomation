using OpenQA.Selenium;
namespace FluentAutomation
{
    public interface ICrudListBasePage<Me>
    {
        IWebElement Filter { get; set; }
        IWebElement CreateNew { get; set; }
        Me Bind();
        Me ViewInfoByIndex(int index = 0);
        Me DoFilter(string query);
        Me DoCreateNew();
    }
}
