using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Throughput_Volume_Update;
using Chargeable_Rates_Updater;
using Reports;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
namespace Commercial_Report
{
    public class CarrierRevenue : ObservableObject
    {
        private string _shippingLine;
        private double _volume;
        private double _revenue;
        private double _yield;


        public string ShippingLine
        {
            get
            { return _shippingLine;}
            set
            { Set<string>(() => this.ShippingLine, ref _shippingLine, value);}
        }

        public double Volume
        {
            get
            { return _volume; }
            set
            { Set<double>(() => this.Volume, ref _volume, value); }
        }
        public double Revenue
        {
            get
            { return _revenue; }
            set
            { Set<double>(() => this.Revenue, ref _revenue, value); }
        }
        public double Yield
        {
            get
            { return _yield; }
            set
            { Set<double>(() => this.Yield, ref _yield, value); }
        }


        public CarrierRevenue(string line)
        {
            IEnumerable<ThroughputVolumeDatabase.AllVesselThroughputVolumeDataRow> _filteredRow;
            ChargeableRatesUpdater Rates = new ChargeableRatesUpdater();
            Rates.OPConnection = new Reports.Connections().OPConnection;

            switch (line)
            {
                case "OTHER":
                    _filteredRow = CarrierThroughput.AllVesselThroughputVolumeDatabase.AllVesselThroughputVolumeData.AsEnumerable()
                    .Where(row => !lineOperatorsToShow.Contains(row.VesselVolume) && 
                    row.Month <= DateTime.Now.Month && 
                    row.Year <= DateTime.Now.Year);
                    break;
                default:
                    _filteredRow = CarrierThroughput.AllVesselThroughputVolumeDatabase.AllVesselThroughputVolumeData.AsEnumerable()
                    .Where(row => row.VesselVolume == line && 
                    row.Month <= DateTime.Now.Month && 
                    row.Year <= DateTime.Now.Year);
                    break;
            }
            this.ShippingLine = Reports.ReportFunctions.GetFullName(line);
            this.Volume = _filteredRow.Sum((vol) => vol.TEU);

            double _stevedoringRevenue = _filteredRow.Sum((vol) => vol.TEU) * Rates.GetRates("STEVEDORING",DateTime.Now.Month,DateTime.Now.Year);
            double _gearboxRevenue = _filteredRow.Sum((vol) => vol.Gearbox20 + vol.Gearbox40) * Rates.GetRates("GEARBOX", DateTime.Now.Month, DateTime.Now.Year);
            double _hatchcoverRevenue = _filteredRow.Sum((vol) => vol.Hatchcover) * Rates.GetRates("HATCHCOVER", DateTime.Now.Month, DateTime.Now.Year);
            double _shiftingRevenue = _filteredRow.Sum((vol) => vol.ShiftEmpty + vol.ShiftFull) * Rates.GetRates("SVD", DateTime.Now.Month, DateTime.Now.Year);
            double _linehandlingRevenue = _filteredRow.Select((vol) => vol.Registry).Distinct().Count() * Rates.GetRates("LINE HANDLING", DateTime.Now.Month, DateTime.Now.Year);
            double _seguidoRevenue = _filteredRow.Sum((vol) => vol.Seguido) * Rates.GetRates("SEGUIDO", DateTime.Now.Month, DateTime.Now.Year);

            this.Revenue = _stevedoringRevenue + _gearboxRevenue + _hatchcoverRevenue + _shiftingRevenue + _linehandlingRevenue + _seguidoRevenue;
            this.Yield = this.Revenue / this.Volume;

        }

        public static ObservableCollection<CarrierRevenue> GenerateCarrierRevenue()
        {
            ObservableCollection<CarrierRevenue> revenue = new ObservableCollection<CarrierRevenue>();
            CarrierThroughput = new AllVesselThroughputVolume();


            Parallel.ForEach(lineOperatorsToShow, (line) =>
            {
                revenue.Add(new CarrierRevenue(line));

            }
            );

            revenue.Add(new CarrierRevenue("OTHER"));

            return revenue;
        }

        private static AllVesselThroughputVolume CarrierThroughput;
        public static String[] lineOperatorsToShow = {"EMC",
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
