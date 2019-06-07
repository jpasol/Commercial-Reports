using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercial_Report
{
    public class DatatableViewModel : NotificationObject
    {
        public DatatableViewModel()
        {
            carrierRevenue = new CarrierRevenue();
        }

        public RevenueDataModel.CarrierRankingDataTable Data
        { get { return carrierRevenue.CarrierRevenueRanking; } }
        
        private CarrierRevenue carrierRevenue;
    }
}
