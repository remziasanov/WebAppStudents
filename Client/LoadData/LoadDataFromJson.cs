using Client.ModelsUI.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.LoadData
{
    public static class LoadDataFromJson<TypeModel> where TypeModel : EntityBaseUI<int>
    {


        public static async Task<List<TypeModel>> LoadList(string url)
        {
            // Для отключения проверки сертификата, использовать только для тестирования
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            List<TypeModel> results = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                  MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<List<TypeModel>>(data);

                }
            }
            return results;

        }
    }
}
