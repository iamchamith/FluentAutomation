using OpenQA.Selenium;
namespace FluentAutomation.ManagePage
{
    public interface IDeleteMangePage<Me>
    {
        IWebElement DeleteButton { get; }
        Me ClickDeleteButton();
    }
}
