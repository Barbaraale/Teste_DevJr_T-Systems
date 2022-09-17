using Newtonsoft.Json;

namespace TorneioLuta.Models
{   
    public class CompetidorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("idade")]
        public int Idade { get; set; }

        [JsonProperty("artesMarciais")]
        public string[] ArtesMarciais { get; set; }

        [JsonProperty("lutas")]
        public int Lutas { get; set; }

        [JsonProperty("derrotas")]
        public int Derrotas { get; set; }

        [JsonProperty("vitorias")]
        public int Vitorias { get; set; }

        public int Porcentagem { get; set; }

        public bool IsCheck { get; set; }
    }
}