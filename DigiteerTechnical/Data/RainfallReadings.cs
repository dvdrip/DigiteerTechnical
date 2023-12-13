using DigiteerTechnical.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DigiteerTechnical.Data
{
    public class RainfallReadings
    {
        public RainfallRoot GetRainfallAPIReadings(string _param, int _count)
        {
            string apiUrl = "https://environment.data.gov.uk/flood-monitoring/data/readings";
            string param = _param;
            int count = _count;

            var client = new RestClient(apiUrl);

            var request = new RestRequest();
            request.AddQueryParameter("parameter", param);
            request.AddQueryParameter("_limit", count);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                RainfallRoot root = JsonConvert.DeserializeObject<RainfallRoot>(response.Content);

                return root;
            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
                return null;
            }

        }
    }
}
