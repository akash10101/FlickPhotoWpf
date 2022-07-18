using PhotoSearch.Services;
using PhotoSearch.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoSearch.Commands
{
    public class NavigationCommand : CommandBase
    {
        private NavigationService _navService;

        public NavigationCommand(NavigationService navigationService)
        {
            _navService = navigationService;
        }
        public override void Execute(object parameter)
        {
            _navService.Navigate();
        }
    }
}