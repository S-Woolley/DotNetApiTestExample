using RestSharp;
using Newtonsoft.Json;

namespace PetStoreRestSharp
{
    internal class IntegrationClient
    {
        private RestClient client;

        public IntegrationClient()
        {
            client = new RestClient("url");
        }

        public RestResponse<T> Authorize<T>(object clientId, object secret)
        {
            var request = new RestRequest("/auth/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
            request.AddParameter("client_id", clientId, ParameterType.GetOrPost);
            request.AddParameter("client_secret", secret, ParameterType.GetOrPost);
            return client.Execute<T>(request);
        }

        public RestResponse SendReferral<T>(string token, string site, string body)
        {
            var request = new RestRequest($"/api/site/{site}/referral", Method.Post);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Authorization", $"bearer {token}");
            request.AddBody(body);
            var response = client.Execute<T>(request);
            Console.Out.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }


        public RestResponse GetReferral<T>(string token, string site, string referralKey)
        {
            var request = new RestRequest($"api/site/{site}/referral/{referralKey}/getreferralstatus", Method.Get);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Authorization", $"bearer {token}");

            var response = client.Execute<T>(request);
            Console.Out.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public RestResponse SendResupplyl<T>(string token, string site, string body)
        {
            var request = new RestRequest($"/api/site/{site}/referral", Method.Post);
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Authorization", $"bearer {token}");
            request.AddBody(body);
            var response = client.Execute<T>(request);
            //TestContext.Out.WriteLine(response.ToString());
            return response;
        }

    }
}