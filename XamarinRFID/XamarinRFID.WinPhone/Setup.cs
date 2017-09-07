using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Platform;
using MvvmCross.WindowsCommon.Platform;
using Windows.UI.Xaml.Controls;

namespace XamarinRFID.WinPhone
{
    public class Setup : MvxWindowsSetup
    {
      

        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }

      

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        //protected override IMvxPhoneViewPresenter CreateViewPresenter(PhoneApplicationFrame rootFrame)
        //{
        //    var presenter = new MvxFormsWindowsPhonePagePresenter(rootFrame);
        //    return presenter;
        //}

        //protected override ImvxPag CreateViewPresenter(Xamarin.Forms.Frame rootFrame)
        //{
        //    var presenter = new MvxFormsWindowsPhonePagePresenter(rootFrame);
        //    return presenter;
        //}

    }
}