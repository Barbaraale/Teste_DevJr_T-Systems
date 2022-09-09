using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioLuta.Repositories.Interfaces;

namespace TorneioLuta.Controllers
{
    public class CompetidorController : Controller
    {
        private readonly ICompetidorRepository _competidorRepository;

        public CompetidorController(ICompetidorRepository competidorRepository)
        {
            _competidorRepository = competidorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var json = await _competidorRepository.GetAll();
            return View(json);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
