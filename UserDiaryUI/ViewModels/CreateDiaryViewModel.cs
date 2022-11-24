using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiaryUI.Commands;

namespace UserDiaryUI.ViewModels
{
    public class CreateDiaryViewModel : ViewModelBase
    {
        private string _name;
        private string _content;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public ICommand CreateDiaryCommand { get; }

        public CreateDiaryViewModel() {
            CreateDiaryCommand = new CreateDiaryCommand();
        }
    }
}
