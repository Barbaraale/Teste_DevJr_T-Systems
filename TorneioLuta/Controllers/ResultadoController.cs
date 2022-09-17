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
            var listOitavas = _resultadoRepository.Duels(competidoresSelecionados, competidoresSelecionados.Count);
            var listQuartas = _resultadoRepository.Duels(listOitavas, listOitavas.Count);
            var listSemi = _resultadoRepository.Duels(listQuartas, listQuartas.Count);
            var final = _resultadoRepository.GetWinner(listSemi);

            ViewBag.selectCompetidor = final;
            return View();
        }
    }
}
