namespace StartOnion.CrossCutting.Utilities.Helpers.BrazilianDocuments
{
    /// <summary>
    /// CPF Helper
    /// </summary>
    public class CpfHelper
    {
        private readonly string _cpf;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="cpf">Número do CPF (com ou sem máscara)</param>
        public CpfHelper(string cpf)
        {
            _cpf = cpf.Trim();
            _cpf = cpf.Replace(".", "").Replace("-", "");
        }

        /// <summary>
        /// O CPF é válido?
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            
            if (_cpf.Length != 11)
                return false;
            tempCpf = _cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return _cpf.EndsWith(digit);
        }
    }
}
