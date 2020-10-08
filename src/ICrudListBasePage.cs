using OpenQA.Selenium;
namespace FluentAutomation
{
    public interface ICrudListBasePage<Me>
    {
        IWebElement Filter { get; set; }
        IWebElement CreateNew { get; set; }
        Me Bind();
        Me ViewInfoByIndex(string index = "0");
        Me DoFilter(string query);
        Me ClickCreateNew();
    }
}
