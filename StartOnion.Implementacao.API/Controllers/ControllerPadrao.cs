using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartOnion.Implementacao.API.Controllers
{
    public abstract class ControllerPadrao : ControllerBase
    {
        [HttpOptions]
        [AllowAnonymous]
        public void Options() { }
    }
}
