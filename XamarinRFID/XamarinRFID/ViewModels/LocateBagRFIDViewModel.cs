using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinRFID
{
    public class LocateBagRFIDViewModel : MvxViewModel
    {
        private string _searchEntry;
        public string SearchEntry
        {
            get { return _searchEntry; }
            set
            {
                _searchEntry = value;
                RaisePropertyChanged(() => SearchEntry);
            }
        }

    //    ObservableCollection<string> _repo = new ObservableCollection<string>()
    //{
    //    "Bag No. 1",
    //    "Bag No. 2",
    //    "Bag No. 3",
    //    "Bag No. 4",
    //    "Bag No. 5", 
    //    "Bag No. 6",
    //    "Bag No. 7",
    //};

    //    public ObservableCollection<string> BagTagNo
    //    {
    //        get
    //        {
    //            return _repo;
    //        }
    //    }


    }
}
