using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class UpdateProfileCommand : CommandBase
    {
        private readonly Cache _cache;
        private readonly UserProfileViewModel _userProfileViewModel;
        private readonly INavigationService _navigationService;

        public UpdateProfileCommand( UserProfileViewModel profileViewModel, Cache cache, INavigationService navigationService)
        {
            _cache = cache;
            _userProfileViewModel = profileViewModel;
            _navigationService = navigationService;
        }

        //public override void CanExecute(object? parameter)
        //{ 
        //}

        public override void Execute(object? parameter)
        {

            if ( (_cache.currentUser.email != _userProfileViewModel.Email ?
                Utility.ValidateEmail(_userProfileViewModel.Email) : true)
                && 
                (_cache.currentUser.phone != _userProfileViewModel.Phone ?
                Utility.ValidatePhone(_userProfileViewModel.Phone) : true))
            {
                _cache.currentUser.UpdateUser(_userProfileViewModel.Name, _userProfileViewModel.Password, _userProfileViewModel.Phone, _userProfileViewModel.Email);
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Incorrect Input!");
            }
            _navigationService.Navigate();
        }

    }
}
