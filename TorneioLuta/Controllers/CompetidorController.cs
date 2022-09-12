using Microsoft.AspNetCore.Mvc;
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
    }
}
