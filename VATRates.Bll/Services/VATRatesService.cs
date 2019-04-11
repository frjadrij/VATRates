using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VATRates.Bll.ViewModels;
using VATRates.Bll.Models;
using VATRates.Bll.Mappers;
using VATRates.Bll.Helpers;
using System.Configuration;

namespace VATRates.Bll.Services
{
    public class VATRatesService : IVATRatesService
    {
        const string URI = "URI";
        HttpClient client = new HttpClient();
    
        public VATRatesService()
        {
            client = HttpClientHelper.InitializeClient(client);
        }

        public async Task<VATRatesVM> InitializeAsync()
        {
            VATRatesVM viewModel = new VATRatesVM();
            try
            {
                HttpResponseMessage response = await client.GetAsync(ConfigurationManager.AppSettings[URI]);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var VATRatesJsonModel = JsonConvert.DeserializeObject<VATRatesJsonModel>(responseJson);

                viewModel = VATRatesJsonModel.MapToViewModel();
            }
            catch(Exception)
            {
                throw;
            }

            return viewModel;
        }
    }
}
