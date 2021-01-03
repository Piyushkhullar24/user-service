using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Token
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("error")]
        //public string Error { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("error_description")]
        //public string ErrorDescription { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("id_token")]
        //public string IdToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("expires_in")]
        //public int ExpiresIn { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("refresh_token")]
        //public string RefreshToken { get; set; }
    }
}
