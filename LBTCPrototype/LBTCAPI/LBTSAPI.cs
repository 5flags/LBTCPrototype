using System;
using System.Collections.Generic;
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

    public class AuthorizeResponse
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }

    public class MyselfResponse
    {
        public Data data
        {
            get; set;
        }

        public class Data
        {
            public string username { get; set; }
            public int trading_partners_count { get; set; }
            public int feedbacks_unconfirmed_count { get; set; }
            public string trade_volume_text { get; set; }
            public bool has_common_trades { get; set; }
            public string confirmed_trade_count_text { get; set; }
            public int blocked_count { get; set; }
            public int feedback_count { get; set; }
            public string url { get; set; }
            public int trusted_count { get; set; }
        }
    }

    public class EscrowsResponse
    {
        IEnumerable<Escrow> escrow_list { get; set; }

        public class Escrow
        {
            public Data data { get; set; }
            public Actions actions { get; set; }

            public class Data
            {
                public string created_at { get; set; }
                public string buyer_username { get; set; }
                public string reference_code { get; set; }
                public string currency { get; set; }
                public string amount { get; set; }
                public string amount_btc { get; set; }
                public string exchange_rate_updated_at { get; set; }
            }

            public class Actions
            {
                public string release_url { get; set; }
            }
        }
    }

    

    
}
