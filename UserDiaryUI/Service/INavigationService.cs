using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Service
{
    public interface INavigationService<ViewModelType>
        where ViewModelType : ViewModelBase
    {
        void Navigate();
    }
}