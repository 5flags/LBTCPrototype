using System;
using LBTCPrototype.LBTCAPI;

namespace LBTCPrototype
{
    class Program
    {
        private const string ClientId = 
        private const string ClientSecre
        private const string Username = 
        private const string Password = 

        static void Main(string[] args)
        {
            LBTSAPI api = new LBTSAPI(Username, Password, ClientId, ClientSecret);

            var response = api.GetMeData();

            Console.WriteLine("***Me***");
            Console.WriteLine("Username                   : {0}", response.data.username);
            Console.WriteLine("Trading partners count     : {0}", response.data.trading_partners_count);
            Console.WriteLine("Uncomfirmed feedback count : {0}", response.data.feedbacks_unconfirmed_count);
            Console.WriteLine("Trade Volume               : {0}", response.data.trade_volume_text);
            Console.WriteLine("Has common trades          : {0}", response.data.has_common_trades);
            Console.WriteLine("Confirmed trade count      : {0}", response.data.confirmed_trade_count_text);
            Console.WriteLine("Blocked Count              : {0}", response.data.blocked_count);
            Console.WriteLine("Feedback count             : {0}", response.data.feedback_count);
            Console.WriteLine("Url                        : {0}", response.data.url);
            Console.WriteLine("Trusted count              : {0}", response.data.trusted_count);
            Console.WriteLine("*********");

            var adsResponse = api.GetAds();

            Console.ReadLine();
        }
    }
}
