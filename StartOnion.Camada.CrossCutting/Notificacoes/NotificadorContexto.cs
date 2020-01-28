using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    public sealed class NotificadorContexto : INotificadorContexto
    {
        private readonly List<string> _notificacoes = new List<string>();
        public IReadOnlyCollection<string> Notificacoes => _notificacoes;

        public void Adicionar(string mensagem) => _notificacoes.Add(mensagem);
        public void Adicionar(ICollection<string> mensagens) => _notificacoes.AddRange(mensagens);
        public void Adicionar(IReadOnlyCollection<string> mensagens) => _notificacoes.AddRange(mensagens);
        public void Adicionar(Notificavel notificavel) => _notificacoes.AddRange(notificavel.ObterNotificacoes());
        public void Adicionar(params Notificavel[] notificaveis)
        {
            foreach (var notificavel in notificaveis)
                Adicionar(notificavel);
        }

        public bool PossuiNotificacoes() => _notificacoes.Any();
    }
}
