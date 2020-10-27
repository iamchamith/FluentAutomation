using OpenQA.Selenium;
namespace FluentAutomation.ListPage
{
    public interface IListOfObjectViewPage<Me>
    {
        IWebElement CreateNewObject { get; } 
        Me ViewInfoByIndex(string index = "0");
        Me ClickCreateNewObject();
        Me AssertPage();
    }
}
