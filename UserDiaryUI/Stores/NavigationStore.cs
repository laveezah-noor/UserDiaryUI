using System;
using System.Windows;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Stores
{
    public class NavigationStore
    {
        ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
