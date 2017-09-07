using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Droid.Views;
using Android.Views;
using MvvmCross.Platform.IoC;

namespace XamarinRFID.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IInitializeService>(new InitializeDatabaseService());
            return new CoreApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxPagePresenter();
            Mvx.RegisterSingleton<IMvxPageNavigationHost>(presenter);
            return presenter;
        }

    
    

    }
}
