﻿using DigiteerTechnical.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DigiteerTechnical.Data
{
    public class RainfallPublicReadings
    {
        public RainfallPublic? GetRainfallAPIReadings(string _id, string _param, int _count)
        {
            string apiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{_id}/readings";
            string param = _param;
            int count = _count;

            var client = new RestClient(apiUrl);

            var request = new RestRequest();
            request.AddQueryParameter("parameter", param);
            request.AddQueryParameter("_limit", count);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                RainfallPublic root = JsonConvert.DeserializeObject<RainfallPublic>(response.Content);

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
