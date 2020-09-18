using System;
using System.Configuration;

namespace MiniHome.Domain
{
    public class GlobalConfig
    {
        private static readonly Lazy<GlobalConfig> lazy = new Lazy<GlobalConfig>(() => new GlobalConfig());
        public static GlobalConfig Current { get { return lazy.Value; } }

        public const string Secret = "MINIHOME2020PARK";

        public readonly string ConnectionString;

        public const string LoginMemberCookieName = "MiniHomeToken";

        public GlobalConfig()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DBConn"].ToString();
        }

        public string GetString(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public bool GetBoolean(string key)
        {
            bool result = false;
            string tmp = this.GetString(key);
            if (!string.IsNullOrWhiteSpace(tmp))
            {
                if (tmp.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                }
            }
            return result;
        }

        public int GetInt(string key)
        {
            int result = 0;
            string tmp = this.GetString(key);
            if (!string.IsNullOrWhiteSpace(tmp))
            {
                if (!int.TryParse(tmp, out result))
                {
                    result = -1;
                }
            }
            return result;
        }
    }
}
