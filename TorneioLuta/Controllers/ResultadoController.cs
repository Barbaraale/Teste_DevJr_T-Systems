using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TorneioLuta.Controllers
{
    public class ResultadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
