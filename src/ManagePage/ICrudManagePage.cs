namespace FluentAutomation.ManagePage
{
    public interface ICrudManagePage<ViewModel, Me>
        : ICommonManagePage<ViewModel, Me>,
         ICreateMangePage<ViewModel, Me>,
        IDeleteMangePage<Me>,
        IUpdateMangePage<ViewModel, Me>
        where ViewModel : class
    {
    }
}
