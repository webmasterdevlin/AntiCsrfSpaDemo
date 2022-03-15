using Microsoft.AspNetCore.Mvc;

namespace AntiCsrfSpaDemo.Controllers.Base;

[ApiController]
[Route("api/")]
[ValidateAntiForgeryToken]
public abstract class ApiController : ControllerBase
{
        
}