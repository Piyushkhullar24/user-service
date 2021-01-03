using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Service.BusinessLogic;

namespace User.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IGitHubService _gitHubService;
        public AuthController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/github-authorize")]
        public async Task<IActionResult> AuthorizeWithGitHub(
            CancellationToken cancellationToken,
            [FromQuery] string code = null)
        {
            var response = await _gitHubService.Authorize(code, false);
            return Ok(response);
        }

    }
}