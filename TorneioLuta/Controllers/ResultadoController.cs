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
        private readonly ICompetidorRepository _competidorRepository;

        public ResultadoController(ICompetidorRepository competidorRepository)
        {
            _competidorRepository = competidorRepository;
        }

        [HttpPost]
        public IActionResult Index(List<CompetidorModel> competidores)
        {
            List<CompetidorModel> competidoresEscolhidos = new List<CompetidorModel>();
            StringBuilder sb = new StringBuilder();

            //pegando os 16 selecionados e calculando a porcentagem de vitorias
            foreach (var item in competidores)
            {
                if (item.IsCheck == true)
                {
                    var porcentagem = (item.Vitorias * 100) / item.Lutas;
                    item.Porcentagem = porcentagem;
                    competidoresEscolhidos.Add(item);
                }
            }

            //ordenando a lista por idades de forma crescente 
            var competidoresOrdemCrescente = competidoresEscolhidos.OrderBy(x => x.Idade).ToList();

            //oitavas ---------------------------------------------------------------------------------------------------------------
            List<CompetidorModel> winnersOitavas = new List<CompetidorModel>();
            int indexOitavas = 0;

            while (indexOitavas < 16)
            {
                var duelos = competidoresOrdemCrescente.GetRange(indexOitavas, 2);

                if (duelos[0].Porcentagem > duelos[1].Porcentagem && duelos[0].Porcentagem != duelos[1].Porcentagem)
                {
                    winnersOitavas.Add(duelos[0]);
                }
                else if (duelos[1].Porcentagem > duelos[0].Porcentagem && duelos[1].Porcentagem != duelos[0].Porcentagem)
                {
                    winnersOitavas.Add(duelos[1]);
                }
                else if (duelos[0].ArtesMarciais.Length > duelos[1].ArtesMarciais.Length && duelos[0].ArtesMarciais.Length != duelos[1].ArtesMarciais.Length)
                {
                    winnersOitavas.Add(duelos[0]);
                }
                else if (duelos[1].ArtesMarciais.Length > duelos[0].ArtesMarciais.Length && duelos[1].ArtesMarciais.Length != duelos[0].ArtesMarciais.Length)
                {
                    winnersOitavas.Add(duelos[1]);
                }
                else if (duelos[0].Lutas > duelos[1].Lutas && duelos[0].Lutas != duelos[1].Lutas)
                {
                    winnersOitavas.Add(duelos[0]);
                }
                else
                {
                    winnersOitavas.Add(duelos[1]);
                }
                indexOitavas += 2;
            }

            //quartas ---------------------------------------------------------------------------------------------------------------
            List<CompetidorModel> winnersQuartas = new List<CompetidorModel>();
            int indexQuartas = 0;

            while (indexQuartas < 8)
            {
                var duelos = winnersOitavas.GetRange(indexQuartas, 2);

                if (duelos[0].Porcentagem > duelos[1].Porcentagem && duelos[0].Porcentagem != duelos[1].Porcentagem)
                {
                    winnersQuartas.Add(duelos[0]);
                }
                else if (duelos[1].Porcentagem > duelos[0].Porcentagem && duelos[1].Porcentagem != duelos[0].Porcentagem)
                {
                    winnersQuartas.Add(duelos[1]);
                }
                else if (duelos[0].ArtesMarciais.Length > duelos[1].ArtesMarciais.Length && duelos[0].ArtesMarciais.Length != duelos[1].ArtesMarciais.Length)
                {
                    winnersQuartas.Add(duelos[0]);
                }
                else if (duelos[1].ArtesMarciais.Length > duelos[0].ArtesMarciais.Length && duelos[1].ArtesMarciais.Length != duelos[0].ArtesMarciais.Length)
                {
                    winnersQuartas.Add(duelos[1]);
                }
                else if (duelos[0].Lutas > duelos[1].Lutas && duelos[0].Lutas != duelos[1].Lutas)
                {
                    winnersQuartas.Add(duelos[0]);
                }
                else
                {
                    winnersQuartas.Add(duelos[1]);
                }
                indexQuartas += 2;
            }

            //semi ---------------------------------------------------------------------------------------------------------------
            List<CompetidorModel> winnersSemi = new List<CompetidorModel>();
            int indexSemi = 0;

            while (indexSemi < 4)
            {
                var duelos = winnersOitavas.GetRange(indexSemi, 2);

                if (duelos[0].Porcentagem > duelos[1].Porcentagem && duelos[0].Porcentagem != duelos[1].Porcentagem)
                {
                    winnersSemi.Add(duelos[0]);                
                }
                else if (duelos[1].Porcentagem > duelos[0].Porcentagem && duelos[1].Porcentagem != duelos[0].Porcentagem)
                {
                    winnersSemi.Add(duelos[1]);
                }
                else if (duelos[0].ArtesMarciais.Length > duelos[1].ArtesMarciais.Length && duelos[0].ArtesMarciais.Length != duelos[1].ArtesMarciais.Length)
                {
                    winnersSemi.Add(duelos[0]);
                }
                else if (duelos[1].ArtesMarciais.Length > duelos[0].ArtesMarciais.Length && duelos[1].ArtesMarciais.Length != duelos[0].ArtesMarciais.Length)
                {
                    winnersSemi.Add(duelos[1]);
                }
                else if (duelos[0].Lutas > duelos[1].Lutas && duelos[0].Lutas != duelos[1].Lutas)
                {
                    winnersSemi.Add(duelos[0]);
                }
                else
                {
                    winnersSemi.Add(duelos[1]);
                }
                indexSemi += 2;
            }

            //final ---------------------------------------------------------------------------------------------------------------
            var dueloFinal = winnersSemi;

            if (dueloFinal[0].Porcentagem > dueloFinal[1].Porcentagem && dueloFinal[0].Porcentagem != dueloFinal[1].Porcentagem)
            {
                winnersSemi.Add(dueloFinal[0]);
                sb.Append(dueloFinal[0].Nome);
            }
            else if (dueloFinal[1].Porcentagem > dueloFinal[0].Porcentagem && dueloFinal[1].Porcentagem != dueloFinal[0].Porcentagem)
            {
                winnersSemi.Add(dueloFinal[1]);
                sb.Append(dueloFinal[1].Nome);
            }
            else if (dueloFinal[0].ArtesMarciais.Length > dueloFinal[1].ArtesMarciais.Length && dueloFinal[0].ArtesMarciais.Length != dueloFinal[1].ArtesMarciais.Length)
            {
                winnersSemi.Add(dueloFinal[0]);
                sb.Append(dueloFinal[0].Nome);
            }
            else if (dueloFinal[1].ArtesMarciais.Length > dueloFinal[0].ArtesMarciais.Length && dueloFinal[1].ArtesMarciais.Length != dueloFinal[0].ArtesMarciais.Length)
            {
                winnersSemi.Add(dueloFinal[1]);
                sb.Append(dueloFinal[1].Nome);
            }
            else if (dueloFinal[0].Lutas > dueloFinal[1].Lutas && dueloFinal[0].Lutas != dueloFinal[1].Lutas)
            {
                winnersSemi.Add(dueloFinal[0]);
                sb.Append(dueloFinal[0].Nome);
            }
            else
            {
                winnersSemi.Add(dueloFinal[1]);
                sb.Append(dueloFinal[1].Nome);
            }

            ViewBag.selectCompetidor = sb.ToString();
            return View();
        }
    }
}
