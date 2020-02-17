using FluentValidation;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Domain.Exceptions;
using System;

namespace StartOnion.Domain
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreationTime { get; protected set; }

        private readonly IValidator _validator;

        public Entity()
        {
            SetProperties();
        }

        public Entity(Guid id)
        {
            Id = id;
            CreationTime = DateTimeOffset.Now;
        }

        public Entity(IValidator validador)
        {
            SetProperties();
            _validator = validador;
        }

        public void Validate()
        {
            if (_validator == default)
                throw new ValidatorNotFoundException();

            AddNotifications(_validator.Validate(this).Errors);
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

        private void SetProperties() {
            Id = Guid.NewGuid();
            CreationTime = DateTimeOffset.Now;
        }
    }
}
