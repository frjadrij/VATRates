using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATRates.Bll.Models
{
    public class VATRatesJsonModel
    {
        [JsonProperty("rates")]
        public List<RateJsonModel> VATRates = new List<RateJsonModel>();
    }

    public class RateJsonModel
    {
        [JsonProperty("name")]
        public string CountryName { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("periods")]
        public List<PeriodJsonModel> Periods = new List<PeriodJsonModel>();
    }

    public class PeriodJsonModel
    {
        [JsonProperty("effective_from")]
        public string EffectiveFrom { get; set; }
        [JsonProperty("rates")]
        public PeriodRatesJsonModel PeriodRates = new PeriodRatesJsonModel();
    }

    public class PeriodRatesJsonModel
    {
        [JsonProperty("standard")]
        public long Standard { get; set; }
        [JsonProperty("reduced")]
        public long Reduced { get; set; }
        [JsonProperty("reduced1")]
        public long Reduced1 { get; set; }
        [JsonProperty("reduced2")]
        public long Reduced2 { get; set; }
        [JsonProperty("super_reduced")]
        public long SuperReduced { get; set; }
        [JsonProperty("parking")]
        public long Parking { get; set; }
    }

}
