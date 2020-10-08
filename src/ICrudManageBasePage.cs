using OpenQA.Selenium;

namespace FluentAutomation
{
    public interface ICrudManageBasePage<ViewModel, Me> where ViewModel : class
    {
        ViewModel _itemViewModel { get; set; }
        public IWebElement Create { get; set; }
        public IWebElement Delete { get; set; }
        public IWebElement ToList { get; set; }
        public IWebElement Update { get; set; }
        Me Bind();
        Me SetValue(ViewModel item);
        Me SetUpdateValue(ViewModel item);
        Me ClickDelete();
        Me ClickCreate();
        Me GoToList();
        Me DoAssert(ViewModel item = null);
    }
}
