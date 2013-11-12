using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace LBTCPrototype.LBTCAPI
{
    public class LBTSAPI
    {
        private const string BaseUrl = "https://localbitcoins.com";

        private readonly string _userName;
        private readonly string _password;
        private readonly string _clientId;
        private readonly string _secret;
        private AuthorizeResponse _authorizeResponse;

        public LBTSAPI(string userName, string password, string clientId, string secret)
        {
            _userName = userName;
            _password = password;
            _clientId = clientId;
            _secret = secret;

            AuthorizeIfNecessary();
        }

        private void AuthorizeIfNecessary()
        {
            if (Properties.Settings.Default.AuthorizeResponse_AccessToken == null ||
                Properties.Settings.Default.AuthorizeResponse_AccessTokenExpiryTime < DateTime.Now)
            {
                var response = Authorize();

                Properties.Settings.Default.AuthorizeResponse_AccessToken = response.access_token;
                Properties.Settings.Default.AuthorizeResponse_AccessTokenExpiryTime = DateTime.Now +
                                                                                      TimeSpan.FromSeconds(
                                                                                          response.expires_in);
                Properties.Settings.Default.AuthorizeResponse_AccessTokenRefreshToken = response.refresh_token;
                Properties.Settings.Default.AuthorizeResponse_AccessTokenScope = response.scope;

                Properties.Settings.Default.Save();
            }
        }

        private AuthorizeResponse Authorize()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;

            var request = new RestRequest("/oauth2/access_token/", Method.POST);

            //client_id, client_secret, username, password, grant_type=password

            request.AddParameter("client_id", _clientId);
            request.AddParameter("client_secret", _secret);
            request.AddParameter("username", _userName);
            request.AddParameter("password", _password);
            request.AddParameter("grant_type", "password");

            var response = client.Execute<AuthorizeResponse>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        public MyselfResponse GetMeData()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;

            var request = new RestRequest("/api/myself/", Method.POST);

            request.AddParameter("access_token", Properties.Settings.Default.AuthorizeResponse_AccessToken);

            var response = client.Execute<MyselfResponse>(request);

            return response.Data;
        }

        public AdsResponse GetAds()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;

            var request = new RestRequest("/api/ads/", Method.POST);

            request.AddParameter("access_token", Properties.Settings.Default.AuthorizeResponse_AccessToken);

            var response = client.Execute<AdsResponse>(request);

            return response.Data;
        }
    }
}
