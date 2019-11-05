using MediatR;
using System;

namespace StartOnion.Camada.Dominio
{
    public class Evento : INotification
    {
        public string Nome { get; set; }
        public DateTime DataDeCriacao => DateTime.Now;
        public virtual string Mensagem { get; set; }
        public virtual bool EhArmazenavel => true;
    }
}
