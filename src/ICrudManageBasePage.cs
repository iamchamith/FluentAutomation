using OpenQA.Selenium;

namespace FluentAutomation
{
    public interface ICrudManageBasePage<ViewModel, Me> where ViewModel : class
    {
        ViewModel _itemViewModel { get; set; }
        IWebElement Save { get; set; }
        IWebElement Delete { get; set; }
        IWebElement ToList { get; set; }
        Me Bind();
        Me SetValue(ViewModel item);
        Me SetUpdateValue(ViewModel item);
        Me DoDelete();
        Me DoSave();
        Me GoToList();
        Me DoAssert(ViewModel item = null);
    }
}
