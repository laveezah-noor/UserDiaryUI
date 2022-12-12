using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiaryUI.Stores;

namespace UserDiaryUI.Commands
{
    public class CloseModalCommand : CommandBase
    {
        ModalNavigationStore _navigationStore;
        public CloseModalCommand(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.Close();
        }
    }
}
