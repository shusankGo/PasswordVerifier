namespace PasswordVerifier
{
    public class PasswordVerify
    {
        public const int MinPassLength = 8;
        static bool VerifyPassword(string password)
        {
            var isValid = true;
            try
            {
                var exceptions = new List<Exception>();
                if (string.IsNullOrWhiteSpace(password))
                {
                    isValid = false;
                    exceptions.Add(new Exception("\nPassword should not be empty"));
                }
                if (password.Length <= MinPassLength)
                {
                    isValid = false;
                    exceptions.Add(new Exception($"\nPassword should be longer than {MinPassLength} characters"));
                }
                if (!password.Any(char.IsUpper))
                {
                    isValid = false;
                    exceptions.Add(new Exception("\nPassword should contain atleast 1 uppercase letter"));
                }
                if (!password.Any(char.IsLower))
                {
                    isValid = false;
                    exceptions.Add(new Exception("\nPassword should contain atleast 1 lowercase letter"));
                }
                if (!password.Any(char.IsDigit))
                {
                    isValid = false;
                    exceptions.Add(new Exception("\nPassword should contain atleast 1 digit"));
                }
                if (exceptions.Count != 0)
                {
                    throw new AggregateException(exceptions);
                }
                return isValid;
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex);
            }
        }
        public static bool PasswordCheck(string password)
        {
            return VerifyPassword(password);
        }
    }
}