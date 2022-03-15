using AntiCsrfSpaDemo.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntiCsrfSpaDemo.Controllers;

[ApiController]
[AllowAnonymous]
[IgnoreAntiforgeryToken]
[Route("api/[controller]")]
public class InitialController : ApiController
{
    [HttpGet]
    public IActionResult InitializeWithCookie()
    {
        return Ok(new {message="first request"});
    }
}