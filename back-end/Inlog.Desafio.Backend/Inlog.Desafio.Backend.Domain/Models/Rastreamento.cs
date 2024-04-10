namespace Inlog.Desafio.Backend.Domain.Models
{
    public class Rastreamento
    {
        public int? Id { get; set; }
        public Veiculo? Veiculo { get; set; }
        public DateTime DataCriacao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
