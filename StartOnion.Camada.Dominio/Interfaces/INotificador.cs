using System.Collections.Generic;

namespace StartOnion.Camada.Dominio.Interfaces
{
    public interface INotificador
    {
        IReadOnlyCollection<string> Notificacoes { get; }
        bool PossuiNotificacoes { get; }

        void Adicionar(string mensagem);
        void Adicionar(ICollection<string> mensagens);
        void Adicionar(IReadOnlyCollection<string> mensagens);
        void Adicionar(Notificavel modeloNotificavel);
        void Adicionar(params Notificavel[] modelosNotificaveis);
    }
}
