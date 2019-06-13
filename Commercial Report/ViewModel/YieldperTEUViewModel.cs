using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Commercial_Report
{
    public class YieldperTEUViewModel : ViewModelBase 
    {
        private ObservableCollection<CarrierRevenue> _revenue;
        public YieldperTEUViewModel()
        {
            _revenue = CarrierRevenue.GenerateCarrierRevenue();
        }

        public ObservableCollection<CarrierRevenue> Revenue
        {
            get { return _revenue; }
        }
    }
}
