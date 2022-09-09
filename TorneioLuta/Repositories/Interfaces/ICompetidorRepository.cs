using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioLuta.Models;

namespace TorneioLuta.Repositories.Interfaces
{
    public interface ICompetidorRepository
    {
        Task<List<CompetidorModel>> GetAll();
    }
}
