using System;
using Microsoft.AspNetCore.Mvc;

using MysticChronicles.PCL.Transports.Internal;

namespace MysticChronicles.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class BaseController : Controller {
        internal BaseManagerConstructorItem BASE_MANAGER => this.HttpContext.Items.ContainsKey("BASE_MANAGER") ? (BaseManagerConstructorItem)HttpContext.Items["BASE_MANAGER"] : new BaseManagerConstructorItem {UserGUID = Guid.Parse("4E521C95-DC3A-4B42-87A5-4DEC07604810") };
    }
}