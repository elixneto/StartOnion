using System.Text.RegularExpressions;

namespace StartOnion.Camada.CrossCutting.Utilidades.Validacoes
{
    public static class ValidacaoDeEmail
    {
        public static bool EhValido(string email)
        {
            var regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");
            return regex.IsMatch(email);
        }
    }
}
