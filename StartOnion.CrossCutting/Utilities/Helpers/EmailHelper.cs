using System.Text.RegularExpressions;

namespace StartOnion.CrossCutting.Utilities.Helpers
{
    /// <summary>
    /// Email helper
    /// </summary>
    public class EmailHelper
    {
        private readonly Regex _regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");
        private readonly string _email;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="email">Email</param>
        public EmailHelper(string email)
        {
            _email = email;
        }

        /// <summary>
        /// The email is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid() => _regex.IsMatch(_email);
    }
}
