using FluentValidation;
using StartOnion.Camada.CrossCutting.Notificacoes;
using System;

namespace StartOnion.Camada.Dominio
{
    public abstract class ObjetoDeValor<T> : Notificavel, IEquatable<T> where T : ObjetoDeValor<T>
    {
        public override bool Equals(object objeto) => this.Equals(objeto as T);
        public virtual bool Equals(T outroObjeto)
        {
            if (ReferenceEquals(null, outroObjeto)) return false;
            if (ReferenceEquals(this, outroObjeto)) return true;
            return PropriedadesIguais(outroObjeto);
        }

        public override int GetHashCode() => this.ObterHashCode();
        public abstract int ObterHashCode();

        public static bool operator ==(ObjetoDeValor<T> a, ObjetoDeValor<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(ObjetoDeValor<T> a, ObjetoDeValor<T> b)
        {
            return !(a == b);
        }

        public abstract bool PropriedadesIguais(T outroObjeto);

        public void Validar(IValidator validador) => base.AdicionarNotificacoes(validador.Validate(this).Errors);
    }
}
