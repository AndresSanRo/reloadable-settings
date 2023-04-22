using Microsoft.AspNetCore.Mvc;
using ReloadableSettings.Services;

namespace ReloadableSettings.Api.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("hello-world")]
        public IActionResult Index()
        {
            return Ok(_settingsService.GetHelloWorldSetting());
        }
    }
}
