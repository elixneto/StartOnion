namespace StartOnion.Camada.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeCNPJ
    {
        private readonly string _cnpj;

        public ValidadorDeCNPJ(string cnpj)
        {
            _cnpj = cnpj.Trim();
            _cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public bool EhValido()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (_cnpj.Length != 14)
                return false;

            tempCnpj = _cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return _cnpj.EndsWith(digito);
        }
    }
}
