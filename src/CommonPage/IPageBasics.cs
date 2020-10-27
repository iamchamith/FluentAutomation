namespace FluentAutomation.CommonPage
{
    public interface IPageBasics<TThis, TVm>
    {
        TThis Validate();
        TThis SetValues(TVm model);
        TThis Execute();
    }
}
