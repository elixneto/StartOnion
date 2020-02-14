using FluentValidation;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Camada.Dominio.Exceptions;
using System;

namespace StartOnion.Camada.Dominio
{
    public abstract class Entidade : Notificavel
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset DataEHoraDeCriacao { get; }

        private readonly IValidator _validador;

        public Entidade()
        {
            CriarId();
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }

        public Entidade(Guid id)
        {
            Id = id;
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }

        public Entidade(IValidator validador)
        {
            CriarId();
            _validador = validador;
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }

        public void Validar()
        {
            if (_validador == default)
                throw new ValidadorNaoInformadoException();

            AdicionarNotificacoes(_validador.Validate(this).Errors);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Id == ((Entidade)obj).Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Entidade e1, Entidade e2) => Equals(e1, e2);
        public static bool operator !=(Entidade e1, Entidade e2) => !Equals(e1, e2);

        private Guid CriarId() => Id = EhTransiente() ? Guid.NewGuid() : Id;
        private bool EhTransiente() => (Id == default || Id == null);
    }
}
