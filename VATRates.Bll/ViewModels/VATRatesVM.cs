using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATRates.Bll.ViewModels
{
    public class VATRatesVM
    {
        public List<VATRateVM> TopThreeRates = new List<VATRateVM>();
        public List<VATRateVM> BottomThreeRates = new List<VATRateVM>();
    }

    public class VATRateVM
    {
        public string Country { get; set; }
        public long StandardRate { get; set; }
        public long ReducedRate { get; set; }
        public long ReducedRate1 { get; set; }
        public long ReducedRate2 { get; set; }
        public long SuperReducedRate { get; set; }
        public long ParkingRate { get; set; }
    }
}
