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
        private readonly INavigationService<LoginViewModel> _navigationService;

        public LogoutCommand(INavigationService<LoginViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Cache.getCache().Logout();
            MessageBox.Show($"{Cache.getCache().currentUser is null}");
            _navigationService.Navigate();
        }
    }
}