using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var competidoresSelecionados = _resultadoRepository.GetSelected(competidores);
            var listOitavas = _resultadoRepository.Duels(competidoresSelecionados, 16);
            var listQuartas = _resultadoRepository.Duels(listOitavas, 8);
            var listSemi = _resultadoRepository.Duels(listQuartas, 4);
            var final = _resultadoRepository.GetWinner(listSemi);

            ViewBag.selectCompetidor = final;
            return View();
        }
    }
}
