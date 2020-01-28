namespace StartOnion.Camada.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeCPF
    {
        private readonly string _cpf;

        public ValidadorDeCPF(string cpf)
        {
            _cpf = cpf.Trim();
            _cpf = cpf.Replace(".", "").Replace("-", "");
        }

        public bool EhValido()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            
            if (_cpf.Length != 11)
                return false;
            tempCpf = _cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return _cpf.EndsWith(digito);
        }
    }
}
