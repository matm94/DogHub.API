using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers;


[ApiController]
[Route("api/[controller]")]
internal class AccountController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => "Account.API";
}
