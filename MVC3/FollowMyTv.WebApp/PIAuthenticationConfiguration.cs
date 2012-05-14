namespace FollowMyTv.WebApp
{
    public class PIAuthenticationConfiguration
    {
        private static readonly PIAuthenticationConfiguration config = new PIAuthenticationConfiguration();
        public static PIAuthenticationConfiguration Current { get { return config; } }

        private const int DEFAULT_TIMEOUT = 2880;

        public PIAuthenticationConfiguration()
        {
            CookieName = ".PIAuth";
            CookiePath = "/";
            Timeout = DEFAULT_TIMEOUT;
            AnonymousUserName = "public";
            LoginUrl = "/Account/LogOn";
            CookieExpiration = 10;
        }

        public string LoginUrl { get; set; }
        public string CookieName { get; set; }
        public string CookiePath { get; set; }
        public int Timeout { get; set; }
        public string AnonymousUserName { get; set; }

        public int CookieExpiration { get; set; }
    }
}