using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinRFID
{
    public class ScanBagtagViewModel : MvxViewModel
    {
        private string _bagtagSearch;
        public string BagTagSearch
        {
            get { return _bagtagSearch; }
            set
            {
                _bagtagSearch = value;
                RaisePropertyChanged(() => BagTagSearch);

            }
        }

        private string _scanPoint;
        public string ScanPoint
        {
            get { return _scanPoint; }
            set
            {
                _scanPoint = value;
                RaisePropertyChanged(() => ScanPoint);

            }
        }


    }
}
