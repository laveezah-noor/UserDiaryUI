using System;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    internal class LogoutCommand : ICommand
    {
            private readonly INavigationService _navigationService;
        private readonly ModalNavigationStore _modalNavigationStore;

        public LogoutCommand(INavigationService navigationService, ModalNavigationStore modalNavigationStore)
        {
            _navigationService = navigationService;
            _modalNavigationStore = modalNavigationStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Cache.getCache().Logout();
            _modalNavigationStore.Close();
            _navigationService.Navigate();
        }
    }
}