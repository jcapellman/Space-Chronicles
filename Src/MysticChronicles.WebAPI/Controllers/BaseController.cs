using Microsoft.AspNetCore.Mvc;

using MysticChronicles.PCL.Transports.Internal;

namespace MysticChronicles.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class BaseController : Controller {
        internal BaseManagerConstructorItem BASE_MANAGER => this.HttpContext.Items.ContainsKey("BASE_MANAGER") ? (BaseManagerConstructorItem)HttpContext.Items["BASE_MANAGER"] : null;
    }
}