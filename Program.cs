using System;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;

namespace ConConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            String val = "";

            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            using (StreamWriter file = File.AppendText("currency.txt"))
            {

                foreach (string s in sAll.AllKeys)
                {

                    using (var httpClient = new HttpClient())
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, sAll.Get(s));
                        var responseMessage = httpClient.SendAsync(request).Result;
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                        var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(responseContent);
                        val = currencyInfo.Rates.First().Mid;

                    }

                    file.WriteLine("Currency: " + s + ", Value: " + val);
                }
            }
        }
    }
}