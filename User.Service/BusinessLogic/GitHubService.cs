using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using User.Service.Models;

namespace User.Service.BusinessLogic
{
    public interface IGitHubService
    {
        /// <summary>
        /// Get a JustGiving user access token
        /// </summary>
        Task<AuthenticationResponse> Authorize(
            string code,
            bool refresh);

    }

    public class GitHubService : IGitHubService
    {
        private readonly IOAuthService _oAuthService;

        public GitHubService(IOAuthService oAuthService)
        {
            _oAuthService = oAuthService ?? throw new ArgumentNullException(nameof(oAuthService));
        }

        public async Task<AuthenticationResponse> Authorize(string code, bool refresh)
        {
            const string url = "https://github.com/login/oauth/access_token";

            var body = new Dictionary<string, string>
            {
                { "grant_type", refresh ? "refresh_token" : "authorization_code" },
                { "redirect_uri", "http://localhost:4200/auth" }
            };
            if (refresh)
            {
                body.Add("refresh_token", "");
            }
            else
            {
                body.Add("code", code);
            }

            try
            {
                var authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"7291d88d7d4e0c8d8ed8:f93cf729b2d6c55d82888db9b04972285249948c"));
                Token tokenResponse = await _oAuthService.PostFormUrlEncoded<Token>(url, body, authorization);
                return new AuthenticationResponse
                {
                    AccessToken = tokenResponse.AccessToken
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
