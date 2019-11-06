using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.Implementacao.Repositorio
{
    public sealed class RepositorioDeEvento : IRepositorioDeEvento
    {
        private readonly ContextoDoBancoDeDados _contexto;

        public RepositorioDeEvento(ContextoDoBancoDeDados contexto)
        {
            _contexto = contexto;
        }

        public void Armazenar(Evento evento)
        {
            var novoEvento = new Evento
            {
                Nome = evento.GetType().Name,
                Mensagem = evento.Mensagem
            };

            if (evento.EhArmazenavel)
                _contexto.Sessao.Store(novoEvento);
        }
    }
}
