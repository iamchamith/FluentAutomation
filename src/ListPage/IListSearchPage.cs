using OpenQA.Selenium;
namespace FluentAutomation.ListPage
{
    public interface IListSearchPage<Me>
    {
        IWebElement SearchQuery { get; }
        IWebElement SearchButton { get; }
        Me ClickSearchButton(string query);
    }
}
