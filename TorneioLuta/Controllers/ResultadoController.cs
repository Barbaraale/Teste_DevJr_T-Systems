using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TorneioLuta.Models;
using TorneioLuta.Repositories.Interfaces;

namespace TorneioLuta.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ICompetidorRepository _competidorRepository;

        public ResultadoController(ICompetidorRepository competidorRepository)
        {
            _competidorRepository = competidorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<CompetidorModel> competidores, CompetidorModel competidor, bool isCheck)
        {
            var json = await _competidorRepository.GetAll();
            StringBuilder sb = new StringBuilder();

            if (isCheck == true)
            {
                foreach (CompetidorModel item in json)
                {
                    if (competidor.Id == item.Id)
                    {
                        competidores.Add(competidor);
                        sb.Append(item.Nome);
                    }
                }
            }

            ViewBag.selectCompetidor = $"Selecionados: " + sb.ToString();
            return View(competidores);
        }

    }
}
