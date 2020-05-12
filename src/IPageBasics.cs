namespace FluentAutomation
{
    public interface IPageBasics<TThis, TVm>
    {
        TThis Bind();
        TThis Validate();
        TThis SetValues(TVm model);
        TThis Execute();
    }
}
