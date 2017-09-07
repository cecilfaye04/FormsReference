using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinRFID.WinPhone
{
    public sealed class MvxFormsWindowsPhonePagePresenter
    //    : IMvxViewPresenter
    {
        public static NavigationPage NavigationPage;

        private Frame _rootFrame;

        public MvxFormsWindowsPhonePagePresenter(
            Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        //public async void Show(MvxViewModelRequest request)
        //{
        //    if (await TryShowPage(request))
        //        return;

        //    Mvx.Error("Skipping request for {0}",
        //        request.ViewModelType.Name);
        //}

        //private async Task<bool> TryShowPage(MvxViewModelRequest request)
        //{
        //    var page = MvxPresenterHelpers.CreatePage(request);
        //    if (page == null)
        //        return false;

        //    var viewModel = MvxPresenterHelpers.LoadViewModel(request);

        //    if (NavigationPage == null)
        //    {
        //        Forms.Init();
        //        NavigationPage = new NavigationPage(page);
        //        _rootFrame.Navigate(new Uri("/MainPage.xaml",
        //            UriKind.Relative));
        //    }
        //    else
        //    {
        //        await NavigationPage.PushAsync(page);
        //    }

        //    page.BindingContext = viewModel;
        //    return true;
        //}

        public async void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxClosePresentationHint)
            {
                await NavigationPage.PopAsync();
            }
        }

        public void AddPresentationHintHandler<THint>(Func<THint, bool> action) where THint : MvxPresentationHint
        {
            throw new NotImplementedException();
        }
    }
}
