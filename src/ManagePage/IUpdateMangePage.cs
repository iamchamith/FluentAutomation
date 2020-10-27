using OpenQA.Selenium;

namespace FluentAutomation.ManagePage
{
    public interface IUpdateMangePage<ViewModel, Me> where ViewModel : class
    {
        IWebElement UpdateButton { get; }
        Me AssertUpdateValues(ViewModel item);
        Me SetUpdateValues(ViewModel item);
        Me AssertUpdatePage();
        Me ClickUpdateButton();
    }
}
