using OpenQA.Selenium;

namespace FluentAutomation.ManagePage
{
    public interface ICommonManagePage<ViewModel, Me> where ViewModel : class
    {
        ViewModel ObjectViewModel { get; }
        IWebElement ToListButton { get; }
        Me ClickToList();
    }
}
