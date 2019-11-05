namespace StartOnion.Camada.Dominio.Interfaces
{
    public interface IRepositorioDeEvento
    {
        void Armazenar(Evento evento);
    }
}
