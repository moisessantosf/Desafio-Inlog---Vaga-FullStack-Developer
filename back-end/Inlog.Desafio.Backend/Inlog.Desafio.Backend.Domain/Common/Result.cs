namespace Inlog.Desafio.Backend.Domain.Common
{
    public class Result<T>
    {
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
        public string? MsgErro { get; set; }
        public T? Data { get; set; }

    }
}
