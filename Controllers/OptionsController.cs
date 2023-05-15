using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public OptionsController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        //read configuration any time(we shouldnt restart app after changing appsettings.jason)
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
