using OpenQA.Selenium;

namespace FluentAutomation.ManagePage
{
    public interface ICreateMangePage<ViewModel, Me> where ViewModel : class
    {
        IWebElement CreateButton { get; }
        Me SetCreationValues(ViewModel item);
        Me AssertCreatePage();
        Me ClickCreateButton();
    }
}
