using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTCPrototype.LBTCAPI
{
    public class AdsResponse
    {
        public Data data { get; set; }

        public class Data
        {
            public List<AdListEntry> ad_list { get; set; }
            public int ad_count { get; set; }

            public class AdListEntry
            {
                public Ad data { get; set; }
                public Actions actions { get; set; }

                public class Actions
                {
                    public string html_form { get; set; }
                    public string public_view { get; set; }
                    public string change_form { get; set; }
                }

                public class Ad
                {
                    public string reference_type { get; set; }
                    public string currency { get; set; }
                    public string account_info { get; set; }
                    public string age_days_coefficient_limit { get; set; }
                    public string first_time_limit_btc { get; set; }
                    public string city { get; set; }
                    public string location_string { get; set; }
                    public string countrycode { get; set; }
                    public string max_amount { get; set; }
                    public double lon { get; set; }
                    public bool sms_verification_required { get; set; }
                    public string online_provider { get; set; }
                    public object email { get; set; }
                    public string volume_coefficient_btc { get; set; }
                    public Profile profile { get; set; }
                    public string trade_type { get; set; }
                    public int ad_id { get; set; }
                    public string temp_price { get; set; }
                    public string min_amount { get; set; }
                    public string temp_price_usd { get; set; }
                    public double lat { get; set; }
                    public string price_equation { get; set; }
                    public bool visible { get; set; }
                    public string created_at { get; set; }

                    public class Profile
                    {
                        public string username { get; set; }
                        public int id { get; set; }
                        public string name { get; set; }
                    }
                }
            }
        }
    }
}
