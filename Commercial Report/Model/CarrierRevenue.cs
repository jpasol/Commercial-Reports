using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Throughput_Volume_Update;

namespace Commercial_Report
{
    public class CarrierRevenue
    {
        public CarrierRevenue()
        {
            CarrierThroughput = new AllVesselThroughputVolume();
            ComputeRanking();
        }

        private void ComputeRanking()
        {
            CarrierRevenueRanking = new RevenueDataModel.CarrierRankingDataTable();
            
            ComputeRankingForChosenCarriers();
            ComputerRevenueForOTHERCarriers();
                       


        }

        private void ComputerRevenueForOTHERCarriers()
        {
                RevenueDataModel.CarrierRankingRow tempRow = CarrierRevenueRanking.NewCarrierRankingRow();
                tempRow.ShippingLine = "OTHERS";
                tempRow.Volume = CarrierThroughput.AllVesselThroughputVolumeDatabase.AllVesselThroughputVolumeData.AsEnumerable()
                    .Where(row => !lineOperatorsToShow.Contains(row.VesselVolume)).Sum(row => row.InboundEmpty20 + row.InboundEmpty40 + row.InboundEmpty45 +
                    row.InboundLoaded20 + row.InboundLoaded40 + row.InboundLoaded45 +
                    row.OutboundEmpty20 + row.OutboundEmpty40 + row.OutboundEmpty45 +
                    row.OutboundLoaded20 + row.OutboundLoaded40 + row.OutboundLoaded45);
            CarrierRevenueRanking.Rows.Add(tempRow);

            
        }

        private void ComputeRankingForChosenCarriers()
        {
            foreach(string line in lineOperatorsToShow)
            {
                RevenueDataModel.CarrierRankingRow tempRow = CarrierRevenueRanking.NewCarrierRankingRow();
                tempRow.ShippingLine = line;
                tempRow.Volume = CarrierThroughput.AllVesselThroughputVolumeDatabase.AllVesselThroughputVolumeData.AsEnumerable()
                    .Where(row => row.VesselVolume == line).Sum(row => row.InboundEmpty20 + row.InboundEmpty40 + row.InboundEmpty45 +
                    row.InboundLoaded20 + row.InboundLoaded40 + row.InboundLoaded45 +
                    row.OutboundEmpty20 + row.OutboundEmpty40 + row.OutboundEmpty45 +
                    row.OutboundLoaded20 + row.OutboundLoaded40 + row.OutboundLoaded45);
                CarrierRevenueRanking.Rows.Add(tempRow);

            }
        }

        private string GetFullName(string line)
        {
            throw new NotImplementedException();
        }
        private AllVesselThroughputVolume CarrierThroughput;
        public RevenueDataModel.CarrierRankingDataTable CarrierRevenueRanking;
        private String[] lineOperatorsToShow = {"EMC",
                                                "APL",
                                                "MSK",
                                                "ORC",
                                                "SIC",
                                                "WHL",
                                                "HLC",
                                                "SIT",
                                                "ONE",
                                                "ZIM",
                                                "RCL",
                                                "COS",
                                                "SUD",
                                                "SSL"};
    }
}
