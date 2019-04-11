using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATRates.Bll.Models;
using VATRates.Bll.ViewModels;

namespace VATRates.Bll.Mappers
{
    public static class VATRatesMapper
    {
        public static VATRatesVM MapToViewModel(this VATRatesJsonModel model)
        {
            if (model == null)
                return null;

            VATRatesVM VATRatesViewModel = new VATRatesVM();
            List<RateJsonModel> topThreeRates = new List<RateJsonModel>();
            List<RateJsonModel> bottomThreeRates = new List<RateJsonModel>();

            GetTopAndBottomRates(ref topThreeRates, ref bottomThreeRates, model);
            MapThreeRatesToViewModel(VATRatesViewModel, topThreeRates, true);
            MapThreeRatesToViewModel(VATRatesViewModel, bottomThreeRates, false, true);
          
            return VATRatesViewModel;
        }


        private static void GetTopAndBottomRates(ref List<RateJsonModel> topThreeRates, ref List<RateJsonModel> bottomThreeRates, VATRatesJsonModel model)
        {
            var topThreeRatePeriods = model.VATRates.Select(r => r.Periods.First()).Select(p => p.PeriodRates)
                .OrderByDescending(pr => pr.Standard)
                .ThenByDescending(pr => pr.Reduced != 0 ? pr.Reduced : pr.Reduced1)
                .ThenByDescending(pr => pr.Reduced2)
                .ThenByDescending(pr => pr.SuperReduced)
                .ThenByDescending(pr => pr.Parking)
                .Take(3).ToList();

            var bottomThreeRatePeriods = model.VATRates.Select(r => r.Periods.First()).Select(p => p.PeriodRates)
                .OrderBy(pr => pr.Standard)
                .ThenBy(pr => pr.Reduced != 0 ? pr.Reduced : pr.Reduced1)
                .ThenBy(pr => pr.Reduced2)
                .ThenBy(pr => pr.SuperReduced)
                .ThenBy(pr => pr.Parking)
                .Take(3).ToList();

            topThreeRates = model.VATRates.Select(r => r)
                .Where(r => topThreeRatePeriods.Contains(r.Periods.First().PeriodRates))
                .ToList();

            bottomThreeRates = model.VATRates.Select(r => r)
                .Where(r => bottomThreeRatePeriods.Contains(r.Periods.First().PeriodRates))
                .ToList();
        }


        private static void MapThreeRatesToViewModel(VATRatesVM VATRatesViewModel, List<RateJsonModel> threeRates, bool topThreeRates = false, bool bottomThreeRates = false)
        {
            foreach (var rate in threeRates)
            {
                VATRateVM VATRateViewModel = new VATRateVM();

                VATRateViewModel.Country = rate.CountryName;
                VATRateViewModel.StandardRate = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.Standard).FirstOrDefault());
                VATRateViewModel.ReducedRate = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.Reduced).FirstOrDefault());
                VATRateViewModel.ReducedRate1 = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.Reduced1).FirstOrDefault());
                VATRateViewModel.ReducedRate2 = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.Reduced2).FirstOrDefault());
                VATRateViewModel.SuperReducedRate = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.SuperReduced).FirstOrDefault());
                VATRateViewModel.ParkingRate = Convert.ToInt64(rate.Periods.Select(p => p.PeriodRates.Parking).FirstOrDefault());

                if (topThreeRates && !bottomThreeRates)
                    VATRatesViewModel.TopThreeRates.Add(VATRateViewModel);
                else if (!topThreeRates && bottomThreeRates)
                    VATRatesViewModel.BottomThreeRates.Add(VATRateViewModel);
            }

            if (topThreeRates && !bottomThreeRates)
            {
                VATRatesViewModel.TopThreeRates = VATRatesViewModel.TopThreeRates
                    .OrderByDescending(i => i.StandardRate)
                    .ThenByDescending(i => i.ReducedRate != 0 ? i.ReducedRate : i.ReducedRate1)
                    .ThenByDescending(i => i.ReducedRate2)
                    .ThenByDescending(i => i.SuperReducedRate)
                    .ThenByDescending(i => i.ParkingRate)
                    .ToList();
            }
                
            else if (!topThreeRates && bottomThreeRates)
            {
                VATRatesViewModel.BottomThreeRates = VATRatesViewModel.BottomThreeRates
                    .OrderBy(i => i.StandardRate)
                    .ThenBy(i => i.ReducedRate != 0 ? i.ReducedRate : i.ReducedRate1)
                    .ThenBy(i => i.ReducedRate2)
                    .ThenBy(i => i.SuperReducedRate)
                    .ThenBy(i => i.ParkingRate)
                    .ToList();
            }
                
        }
    }
}
