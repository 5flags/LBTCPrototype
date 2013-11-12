namespace LBTCPrototype.LBTCAPI
{
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
}