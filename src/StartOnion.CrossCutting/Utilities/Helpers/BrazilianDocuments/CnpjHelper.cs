namespace StartOnion.CrossCutting.Utilities.Helpers.BrazilianDocuments
{
    /// <summary>
    /// CNPJ Helper
    /// </summary>
    public class CnpjHelper
    {
        private readonly string _cnpj;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="cnpj">Número do CNPJ (com ou sem másccara)</param>
        public CnpjHelper(string cnpj)
        {
            _cnpj = cnpj.Trim();
            _cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        /// <summary>
        /// O CNPJ é válido?
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;

            if (_cnpj.Length != 14)
                return false;

            tempCnpj = _cnpj.Substring(0, 12);
            sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * mult1[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tempCnpj += digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * mult2[i];
            rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return _cnpj.EndsWith(digit);
        }
    }
}
