namespace StartOnion.Camada.Aplicacao.Interfaces
{
    public interface IConsulta
    {
        ResultadoDeConsulta Obter(int pagina, int quantidade);
    }
}
