using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorneioLuta.Models;
using TorneioLuta.Repositories.Interfaces;

namespace TorneioLuta.Repositories
{
    public class ResultadoRepository : IResultadoRepository
    {
        public List<CompetidorModel> GetSelected(List<CompetidorModel> competidores)
        {
            List<CompetidorModel> competidoresEscolhidos = new List<CompetidorModel>();
         
            foreach (var item in competidores)
            {
                if (item.IsCheck == true)
                {
                    var percentage = (item.Vitorias * 100) / item.Lutas;
                    item.Porcentagem = percentage;
                    competidoresEscolhidos.Add(item);
                }
            }
            return competidoresEscolhidos.OrderBy(x => x.Idade).ToList(); ;
        }

        public List<CompetidorModel> Duels(List<CompetidorModel> competidores, int numberCompetidores)
        {
            List<CompetidorModel> winners = new List<CompetidorModel>();
            int index = 0;

            while (index < numberCompetidores)
            {
                var duelos = competidores.GetRange(index, 2);

                if (duelos[0].Porcentagem > duelos[1].Porcentagem && duelos[0].Porcentagem != duelos[1].Porcentagem)
                {
                    winners.Add(duelos[0]);
                }
                else if (duelos[1].Porcentagem > duelos[0].Porcentagem && duelos[1].Porcentagem != duelos[0].Porcentagem)
                {
                    winners.Add(duelos[1]);
                }
                else if (duelos[0].ArtesMarciais.Length > duelos[1].ArtesMarciais.Length && duelos[0].ArtesMarciais.Length != duelos[1].ArtesMarciais.Length)
                {
                    winners.Add(duelos[0]);
                }
                else if (duelos[1].ArtesMarciais.Length > duelos[0].ArtesMarciais.Length && duelos[1].ArtesMarciais.Length != duelos[0].ArtesMarciais.Length)
                {
                    winners.Add(duelos[1]);
                }
                else if (duelos[0].Lutas > duelos[1].Lutas && duelos[0].Lutas != duelos[1].Lutas)
                {
                    winners.Add(duelos[0]);
                }
                else
                {
                    winners.Add(duelos[1]);
                }
                index += 2;
            }
            return winners;
        }

        public string GetWinner(List<CompetidorModel> finalists)
        {
            StringBuilder winner = new StringBuilder();
            var dueloFinal = finalists;

            if (dueloFinal[0].Porcentagem > dueloFinal[1].Porcentagem && dueloFinal[0].Porcentagem != dueloFinal[1].Porcentagem)
            {
                winner.Append(dueloFinal[0].Nome);
            }
            else if (dueloFinal[1].Porcentagem > dueloFinal[0].Porcentagem && dueloFinal[1].Porcentagem != dueloFinal[0].Porcentagem)
            {
                winner.Append(dueloFinal[1].Nome);
            }
            else if (dueloFinal[0].ArtesMarciais.Length > dueloFinal[1].ArtesMarciais.Length && dueloFinal[0].ArtesMarciais.Length != dueloFinal[1].ArtesMarciais.Length)
            {
                winner.Append(dueloFinal[0].Nome);
            }
            else if (dueloFinal[1].ArtesMarciais.Length > dueloFinal[0].ArtesMarciais.Length && dueloFinal[1].ArtesMarciais.Length != dueloFinal[0].ArtesMarciais.Length)
            {
                winner.Append(dueloFinal[1].Nome);
            }
            else if (dueloFinal[0].Lutas > dueloFinal[1].Lutas && dueloFinal[0].Lutas != dueloFinal[1].Lutas)
            {
                winner.Append(dueloFinal[0].Nome);
            }
            else
            {
                winner.Append(dueloFinal[1].Nome);
            }

            return winner.ToString();
        }
    }
}
