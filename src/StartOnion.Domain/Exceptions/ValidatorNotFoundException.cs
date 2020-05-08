using System;

namespace StartOnion.Domain.Exceptions
{
    public class ValidatorNotFoundException : Exception
    {
        public ValidatorNotFoundException() : base("The validator wasn't found. Use the correct constructor.")
        {

        }
    }
}
