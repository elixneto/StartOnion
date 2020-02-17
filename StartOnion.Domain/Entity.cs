using FluentValidation;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Domain.Exceptions;
using System;

namespace StartOnion.Domain
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset DataEHoraDeCriacao { get; protected set; }

        private readonly IValidator _validador;

        public Entity()
        {
            CriarPropriedades();
        }

        public Entity(Guid id)
        {
            Id = id;
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }

        public Entity(IValidator validador)
        {
            CriarPropriedades();
            _validador = validador;
        }

        public void Validar()
        {
            if (_validador == default)
                throw new ValidatorNotFoundException();

            AddNotifications(_validador.Validate(this).Errors);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Id == ((Entity)obj).Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Entity e1, Entity e2) => Equals(e1, e2);
        public static bool operator !=(Entity e1, Entity e2) => !Equals(e1, e2);

        private void CriarPropriedades() {
            Id = Guid.NewGuid();
            DataEHoraDeCriacao = DateTimeOffset.Now;
        }
    }
}
