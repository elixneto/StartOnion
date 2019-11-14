using FluentValidation;
using System;

namespace StartOnion.Camada.Dominio
{
    public abstract class Entidade : Notificavel
    {
        public string Id { get; protected set; }

        public Entidade()
        {
            this.Id = this.Id ?? Guid.NewGuid().ToString();
        }

        public void Validar(IValidator validador) => base.AdicionarNotificacoes(validador.Validate(this).Errors);

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
    }
}
