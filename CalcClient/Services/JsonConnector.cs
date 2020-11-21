using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonLibrary;
using System.Net.Http;

namespace TrainingApp.Services
{
    class JsonConnector : IClient
    {
        readonly string _url;

        public JsonConnector(string url) =>
            _url = url;

        public  async Task<double> Connect(double first, string action, double second)
        {

            var requestData = new JsonData()
            {
                firstValue = first.ToString(),
                oper = action,
                secondValue = second.ToString()
            };
            var jsonString = JsonSerializer.Serialize(requestData);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonString);
                var requsest = await client.PostAsync(_url, content);
                var response = await requsest.Content.ReadAsStringAsync();
                return  Convert.ToDouble(response);
            }
        }


    }
}
