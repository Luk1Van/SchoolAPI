using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Controllers
{
    [Route("api/v{version:apiversion}/students")]
    [ApiVersion("2.0")]
    [ApiController]
    public class Students2Controller : ControllerBase
    {

    }
}
