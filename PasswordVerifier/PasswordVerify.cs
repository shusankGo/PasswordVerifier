namespace PasswordVerifier
{
    public class PasswordVerify
    {
        public const int MinPassLength = 8;
        static bool VerifyPassword(string password)
        {
            bool isValid = true; //set true by default
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    isValid = false;
                    throw new ArgumentException("Password should not be empty\n");
                }
                if (password.Length < MinPassLength)
                {
                    isValid = false;
                    throw new ArgumentException("Password should be longer than 8 characters\n");
                }
                if (!password.Any(char.IsUpper))
                {
                    isValid = false;
                    throw new ArgumentException("Password should have at least one uppercase letter\n");
                }
                if (!password.Any(char.IsLower))
                {
                    isValid = false;
                    throw new ArgumentException("Password should have at least one lowercase letter\n");
                }
                if (!password.Any(char.IsDigit))
                {
                    isValid = false;
                    throw new ArgumentException("Password should have at least one digit\n");
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Password is not valid.", e.Message); //throw exceptions
            }
            return isValid;
        }
        public static bool PasswordCheck(string password)
        {
            return VerifyPassword(password);
        }
    }
}