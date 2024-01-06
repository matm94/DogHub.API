using Account.Core;

namespace Account.API.Controllers;


[ApiController]
[Route("api/[controller]")]
internal class AccountController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => throw new UserNotFoundException(Guid.NewGuid());
}
