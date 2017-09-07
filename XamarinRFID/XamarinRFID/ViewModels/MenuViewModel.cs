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
    public class MenuViewModel : MvxViewModel
    {
        public ICommand ShowLocateBagCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocateBagViewModel>());
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var user = await Mvx.Resolve<IDataService>().LoadUserAsync();
                    user.IsLoggedIn = false;
                    await Mvx.Resolve<IDataService>().UpdateAsync(user);
                    ShowViewModel<LoginViewModel>();
                });
            }
        }

        public ICommand ShowScanCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ScanBagtagViewModel>());
            }
        }
        
                public ICommand ShowLocateBagRFIDCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocateBagRFIDViewModel>());
            }
        }
    }
}
