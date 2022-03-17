using AntiCsrfSpaDemo.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntiCsrfSpaDemo.Controllers;

[ApiController]
[AllowAnonymous]
[IgnoreAntiforgeryToken]
[Route("api/[controller]")]
public class InitialCookieController : ApiController
{
    [HttpGet]
    public IActionResult GetInitialCookie() => Ok(new {message="first request"});
}