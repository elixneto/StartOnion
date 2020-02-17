using FluentValidation;

namespace StartOnion.CrossCutting.Notifications
{
    /// <summary>
    /// Notifiable classes validator
    /// </summary>
    /// <typeparam name="T">Notifiable class</typeparam>
    public abstract class Validator<T> : AbstractValidator<T>
    {
        
    }
}
