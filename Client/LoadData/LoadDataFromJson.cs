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
using System.Windows.Controls;

namespace Client.LoadData
{
    public static class LoadDataFromJson<TypeModel> where TypeModel : EntityBaseUI<int>
    {

        public static async Task<string> GetData(string url)
        {
            string data = "";
            // Для отключения проверки сертификата, использовать только для тестирования
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                  MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        data = await response.Content.ReadAsStringAsync();

                    }
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    return null;
                }
            }
            return data;

        }

        public static async Task<List<TypeModel>> LoadList(string url)
        {
            List<TypeModel> results = null;
            string data = await GetData(url);
            if (data != null)
                results = JsonConvert.DeserializeObject<List<TypeModel>>(data);
            return results;

        }


        public static async Task<TypeModel> LoadModel(string url)
        {
            TypeModel result = null;
            string data = await GetData(url);
            if (data != null)
                result = JsonConvert.DeserializeObject<TypeModel>(data);
            return result;


        }
        public static async Task<string> Add(string url, TypeModel modelobject)
        {
            // Для отключения проверки сертификата, использовать только для тестирования
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => { return true; };
            TypeModel result = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                  MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(modelobject), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return null;

                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    return ex.Message.ToString();
                }
            }
            return null;
        }
    }
}
