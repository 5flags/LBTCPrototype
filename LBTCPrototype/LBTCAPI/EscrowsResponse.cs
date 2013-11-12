using System.Collections.Generic;

namespace LBTCPrototype.LBTCAPI
{
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