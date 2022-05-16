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
                    isTrue = false;
                    throw new Exception("Password should not be empty");

                }
                if (password.Length < 8)
                {
                    isTrue = false;
                    throw new Exception("Password should be longer than 8 characters");

                }
                if (!password.Any(char.IsUpper))
                {
                    isTrue = false;
                    throw new Exception("Password should have at least one uppercase letter");

                }
                if (!password.Any(char.IsLower))
                {
                    isTrue = false;
                    throw new Exception("Password should at least one lowercase letter");

                }
                if (!password.Any(char.IsDigit))
                {
                    isTrue = false;
                    throw new Exception("Password should have at least one digit");

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