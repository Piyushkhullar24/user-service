using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace User.Service.BusinessLogic
{
    /// <summary>
    /// A singleton HttpClient instance that is shared across the application.
    /// It has no special configuration (no BaseAddress, no DefaultHeaders, etc).
    /// Each class that consumes this HttpClient will set all information about the URL, Headers, etc on each HttpRequestMessage.
    /// </summary>
    public interface IGenericHttpClient
    {
        /// <summary>
        /// send an http request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }

    internal class GenericHttpClient : IGenericHttpClient
    {
        private readonly HttpClient _httpClient;

        public GenericHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _httpClient.SendAsync(request, cancellationToken);
        }
    }
}
