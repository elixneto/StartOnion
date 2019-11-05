using FluentValidation;
using System;

namespace StartOnion.Camada.Dominio
{
    public abstract class Entidade : Notificavel
    {
        public string Id { get; private set; }

        public Entidade()
        {
            this.Id = this.Id ?? Guid.NewGuid().ToString();
        }

        public void Validar(IValidator validador) => base.AdicionarNotificacoes(validador.Validate(this).Errors);
    }
}
