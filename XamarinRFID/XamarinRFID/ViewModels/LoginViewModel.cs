using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinRFID
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IUserService _service;
        private readonly IUserDialogs _udialog;
        private readonly IDataService _dataService;

        public LoginViewModel(IUserService service, IUserDialogs dialog, IDataService dataService)
        {
            _service = service;
            _udialog = dialog;
            _dataService = dataService;
        }

        private string _userName;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ICommand ShowMenuPageCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    if (await _service.ValidateLogin(Username, Password))
                    {
                        var user = await Mvx.Resolve<IDataService>().LoadUserAsync();
                        user.IsLoggedIn = true;
                        await Mvx.Resolve<IDataService>().UpdateAsync(user);
                        ShowViewModel<MenuViewModel>();
                    }
                    else
                    {
                        _udialog.Alert("Incorrect Username or Password");
                    }
                });
            }
        }

        public ICommand ShowSignUpCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SignupViewModel>());
            }
        }
    }
}
