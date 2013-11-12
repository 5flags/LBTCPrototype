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

            _authorizeResponse = Authorize();
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
    }
}
