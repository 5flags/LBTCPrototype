﻿namespace LBTCPrototype.LBTCAPI
{
    public class AuthorizeResponse
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}