using System.Collections.Generic;
using TorneioLuta.Models;

namespace TorneioLuta.Repositories.Interfaces
{
    public interface IResultadoRepository
    {
        List<CompetidorModel> GetSelected(List<CompetidorModel> competidores);

        List<CompetidorModel> Duels(List<CompetidorModel> competidores, int numberCompetidores);

        string GetWinner(List<CompetidorModel> finalists);
    }
}
