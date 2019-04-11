using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VATRates.Bll.Helpers
{
    public static class HttpClientHelper
    {
        const string Accept = "Accept";
        const string AcceptEncoding = "AcceptEncoding";
        const string AcceptLanguage = "AcceptLanguage";
        const string Connection = "Connection";
        const string DNT = "DNT";
        const string Host = "Host";
        const string UpgradeInsecureRequests = "Upgrade-Insecure-Requests";
        const string UserAgent = "UserAgent";

        public static HttpClient InitializeClient(HttpClient client)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.ParseAdd(ConfigurationManager.AppSettings[Accept]);
            client.DefaultRequestHeaders.AcceptEncoding.ParseAdd(ConfigurationManager.AppSettings[AcceptEncoding]);
            client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(ConfigurationManager.AppSettings[AcceptLanguage]);
            client.DefaultRequestHeaders.Connection.ParseAdd(ConfigurationManager.AppSettings[Connection]);
            client.DefaultRequestHeaders.Add(DNT, ConfigurationManager.AppSettings[DNT]);
            client.DefaultRequestHeaders.Add(Host, ConfigurationManager.AppSettings[Host]);
            client.DefaultRequestHeaders.Add(UpgradeInsecureRequests, ConfigurationManager.AppSettings[UpgradeInsecureRequests]);
            client.DefaultRequestHeaders.UserAgent.ParseAdd(ConfigurationManager.AppSettings[UserAgent]);

            return client;
        }
    }
}
