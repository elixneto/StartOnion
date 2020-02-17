using FluentValidation;
using StartOnion.CrossCutting.Notifications;
using StartOnion.Domain.Exceptions;
using System;

namespace StartOnion.Domain
{
    public abstract class ValueObject<T> : Notifiable, IEquatable<T> where T : ValueObject<T>
    {
        private readonly IValidator _validator;

        public ValueObject() { }
        public ValueObject(IValidator validator)
        {
            _validator = validator;
        }

        public void Validate()
        {
            if (_validator == null)
                throw new ValidatorNotFoundException();

            AddNotifications(_validator.Validate(this).Errors);
        }

        public override bool Equals(object obj) => this.Equals(obj as T);
        public virtual bool Equals(T otherObj)
        {
            if (ReferenceEquals(null, otherObj)) return false;
            if (ReferenceEquals(this, otherObj)) return true;
            return CustomEquals(otherObj);
        }        
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b) => !(a == b);

        public override int GetHashCode() => CustomGetHashCode();

        public abstract bool CustomEquals(T otherObj);
        public abstract int CustomGetHashCode();
    }
}
