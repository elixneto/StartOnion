using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartOnion.Api.Controllers
{
    public abstract class DefaultController : ControllerBase
    {
        [HttpOptions]
        [AllowAnonymous]
        public void Options() { }
    }
}
