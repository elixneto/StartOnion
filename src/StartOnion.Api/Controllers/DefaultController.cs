using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace StartOnion.Api.Controllers
{
    public abstract class DefaultController : ControllerBase
    {
        [HttpOptions]
        [AllowAnonymous]
        public void Options() { }

        [NonAction]
        protected CreatedResult Created() => Created(string.Empty, default);
        [NonAction]
        protected CreatedResult Created(object obj) => Created(string.Empty, JsonSerializer.Serialize(obj));
    }
}
