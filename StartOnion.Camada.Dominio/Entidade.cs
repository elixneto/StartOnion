using FluentValidation;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Camada.Dominio.Exceptions;
using System;

namespace StartOnion.Camada.Dominio
{
    public abstract class Entidade : Notificavel
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset DataEHoraDeCriacao { get; protected set; }

        private readonly IValidator _validador;

        public Entidade()
        {
            CriarPropriedades();
        }

        public Entidade(Guid id)
        {
            Id = id;
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }

        public Entidade(IValidator validador)
        {
            CriarPropriedades();
            _validador = validador;
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

        private void CriarPropriedades() {
            Id = Guid.NewGuid();
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }
    }
}
