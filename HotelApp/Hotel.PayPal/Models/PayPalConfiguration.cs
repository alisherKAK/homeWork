using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.PayPal.Models
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
            ClientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            var config = ConfigManager.Instance.GetProperties();
            return config;
        }

        //Create access token
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        //This will return APIContext 
        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}