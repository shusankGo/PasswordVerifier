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
                var exceptions = new List<Exception>(); //list of exceptions to catch
                if (string.IsNullOrWhiteSpace(password))
                {
                    isValid = false;
                    exceptions.Add(new ArgumentNullException("Password should not be empty\n"));
                }
                if (password.Length < MinPassLength)
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should be longer than 8 characters\n"));
                }
                if (!password.Any(char.IsUpper))
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one uppercase letter\n"));
                }
                if (!password.Any(char.IsLower))
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one lowercase letter\n"));
                }
                if (!password.Any(char.IsDigit))
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one digit\n"));
                }
                if (exceptions != null)
                {
                    throw new AggregateException(exceptions); //throw all the errors if any present in list
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            return isValid;
        }
        public static bool PasswordCheck(string password)
        {
            return VerifyPassword(password); 
        }
    }
}