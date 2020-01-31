using FluentValidation;

namespace StartOnion.Camada.CrossCutting.Notificacoes
{
    /// <summary>
    /// Validador de classes notificáveis
    /// </summary>
    /// <typeparam name="T">Classe notificável</typeparam>
    public abstract class Validador<T> : AbstractValidator<T>
    {
        
    }
}
