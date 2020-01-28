using System.Collections.Generic;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    public interface INotificadorContexto
    {
        IReadOnlyCollection<string> Notificacoes { get; }

        void Adicionar(string mensagem);
        void Adicionar(ICollection<string> mensagens);
        void Adicionar(IReadOnlyCollection<string> mensagens);
        void Adicionar(Notificavel modeloNotificavel);
        void Adicionar(params Notificavel[] modelosNotificaveis);

        bool PossuiNotificacoes();
    }
}
