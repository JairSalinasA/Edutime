using System.Text.RegularExpressions;

namespace EduTime.Presentation.Helpers
{
    public static class ValidationHelper
    {
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            // Ejemplo simple de validación: al menos 6 caracteres
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}
