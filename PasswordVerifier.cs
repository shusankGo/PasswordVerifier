namespace PasswordVerifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your password: ");
            string password;
            password = Console.ReadLine();
            bool isTrue = true;
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Password should not be empty");
                    isTrue = false;
                }
                if (password.Length < 8)
                {
                    throw new Exception("Password should be longer than 8 characters");
                    isTrue = false;
                }
                if (!password.Any(char.IsUpper))
                {
                    throw new Exception("Password should have at least one uppercase letter");
                    isTrue = false;
                }
                if (!password.Any(char.IsLower))
                {
                    throw new Exception("Password should at least one lowercase letter");
                    isTrue = false;
                }
                if (!password.Any(char.IsDigit))
                {
                    throw new Exception("Password should have at least one digit");
                    isTrue = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }

            if (isTrue)
                Console.WriteLine("Password Valid");
            else
                Console.WriteLine("Password Invalid");

        }
    }
}