using PhotoSearch.Services;


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