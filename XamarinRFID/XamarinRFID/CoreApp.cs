using System;
using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms;
using SQLite;
using SQLite.Net;
using SQLite.Net.Async;

namespace XamarinRFID
{
    public class CoreApp : MvvmCross.Core.ViewModels.MvxApplication
    {

        public static SQLiteAsyncConnection Connection { get; set; }

        public async override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            await Mvx.Resolve<IInitializeService>().InitializeAsync();


            var user = await Mvx.Resolve<IDataService>().LoadUserAsync();
            if (user.IsLoggedIn)
            { this.RegisterAppStart<MenuViewModel>(); }
            else { this.RegisterAppStart<LoginViewModel>(); }



        }

    }
}
