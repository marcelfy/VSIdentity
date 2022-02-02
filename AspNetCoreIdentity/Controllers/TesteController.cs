using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreIdentity.Controllers
{
    public class TesteController : Controller
    {
        private readonly Ilogger<TesteController> _logger;

        public TesteController(Ilogger<TesteController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            _logger.LogError("Esse erro aconteceu");
            return View();
        }
    }
}
