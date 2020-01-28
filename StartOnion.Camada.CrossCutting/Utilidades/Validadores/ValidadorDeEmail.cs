using System.Text.RegularExpressions;

namespace StartOnion.Camada.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeEmail
    {
        private readonly Regex _regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");
        private readonly string _email;

        public ValidadorDeEmail(string email)
        {
            _email = email;
        }

        public bool EhValido() => _regex.IsMatch(_email);
    }
}
