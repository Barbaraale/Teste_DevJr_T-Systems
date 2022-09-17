using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorneioLuta.Models;
using TorneioLuta.Repositories.Interfaces;

namespace TorneioLuta.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly IResultadoRepository _resultadoRepository;

        public ResultadoController(IResultadoRepository resultadoRepository)
        {
            _resultadoRepository = resultadoRepository;
        }

        [HttpPost]
        public IActionResult Index(List<CompetidorModel> competidores)
        {
            ViewBag.selectCompetidor = _resultadoRepository.GetWinner(competidores);
            return View();
        }
    }
}
