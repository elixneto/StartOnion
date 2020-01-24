using StartOnion.Camada.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StartOnion.Camada.Dominio
{
    public sealed class Notificador : INotificador
    {
        private readonly List<string> _notificacoes = new List<string>();
        public IReadOnlyCollection<string> Notificacoes => _notificacoes;

        public void Adicionar(string mensagem) => this._notificacoes.Add(mensagem);
        public void Adicionar(ICollection<string> mensagens) => this._notificacoes.AddRange(mensagens);
        public void Adicionar(IReadOnlyCollection<string> mensagens) => this._notificacoes.AddRange(mensagens);
        public void Adicionar(Notificavel entidade) => this._notificacoes.AddRange(entidade.ObterNotificacoes());
        public void Adicionar(params Notificavel[] entidades)
        {
            foreach (var entidade in entidades)
                this.Adicionar(entidade);
        }

        public bool PossuiNotificacoes() => this._notificacoes.Any();
    }
}
