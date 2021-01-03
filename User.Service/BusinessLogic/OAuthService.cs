using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using User.Service.Extensions;

namespace User.Service.BusinessLogic
{
    /// <summary>
    /// Helper methods for common OAuth tasks
    /// </summary>
    public interface IOAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        Task<TResult> PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData, string authHeader = null);
    }

    /// <summary>
    /// Helper methods for common OAuth tasks
    /// </summary>
    internal class OAuthService : IOAuthService
    {
        private readonly IGenericHttpClient _httpClient;

        public OAuthService(IGenericHttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        public async Task<TResult> PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData, string authHeader = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (!string.IsNullOrEmpty(authHeader))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            }
            using (var content = new FormUrlEncodedContent(postData))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                request.Headers.Add("Accept", "application/json");
                request.Content = content;


                HttpResponseMessage response = await _httpClient.SendAsync(request, CancellationToken.None);
                var ss = response.Content.ReadAsStringAsync();
                return await response.Content.ReadAsAsync<TResult>();
            }
        }
    }
}