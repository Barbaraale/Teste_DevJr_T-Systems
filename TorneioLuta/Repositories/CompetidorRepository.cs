using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TorneioLuta.Models;
using TorneioLuta.Repositories.Interfaces;

namespace TorneioLuta.Repositories
{
    public class CompetidorRepository : ICompetidorRepository 
    {
        public async Task<List<CompetidorModel>> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores");
            request.Headers.Add("x-api-key", "29452a07-5ff9-4ad3-b472-c7243f548a33");

            using (var client = new HttpClient())
            {
                HttpResponseMessage sendResponse = await client.SendAsync(request);
                var response = await sendResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<CompetidorModel>>(response);
                return data;
            }
        }
    }
}
