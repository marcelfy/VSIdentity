using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        public IActionResult Privacy()
        {
            throw new Exception("Erro");
            return View();
        }

        
        public IActionResult Error(int Id)
        {
            var modelErro = new ErrorViewModel();

            if (Id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro!";
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.ErrorCode = Id;
            }else if(Id == 404)
            {
                modelErro.Mensagem = "Ocorreu um erro!";
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.ErrorCode = Id;
            }else if (Id == 403)
            {
                modelErro.Mensagem = "Ocorreu um erro!";
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.ErrorCode = Id;
            }
            else
            {
                return StatusCode(404);
            }
            return View("Error");
        }
    }
}
