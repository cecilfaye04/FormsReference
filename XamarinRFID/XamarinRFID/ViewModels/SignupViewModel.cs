using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinRFID
{
    public class SignupViewModel : MvxViewModel
    {
        private readonly IUserDialogs _udialog;

        public SignupViewModel(IUserDialogs dialog)
        {
            _udialog = dialog;
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
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

        public ICommand SignUpCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    //var user = new UserModel() {
                    //    Username = UserName,
                    //    IsLoggedIn = false
                    //};
                    //await Mvx.Resolve<IDataService>().InsertAsync(user);
                    _udialog.Alert("Successfully Registered");
                    ShowViewModel<LoginViewModel>();
                });
            }
        }
    }
}
