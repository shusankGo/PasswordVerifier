namespace PasswordVerifier
{
    internal class PasswordVerify
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

        static string ReturnPassword()
        {
            Console.WriteLine("Enter your password: ");
            string password = "";
            //for entering password as asterik '*'
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) // Backspace Should Not Work 
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter) //Enter key terminates the program
                    {
                        Console.WriteLine("");
                        break;
                    }
                }
            } while (true);
            return password;
        }

        static void Main(string[] args)
        {
            string password = ReturnPassword();

            if (VerifyPassword(password))
                Console.WriteLine("Password Valid");
            else
                Console.WriteLine("Password Invalid");
        }
    }
}