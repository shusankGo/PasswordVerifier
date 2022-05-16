using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifier
{
    internal class PasswordVerification
    {
        static int MIN_PASS_LENGTH = 8; //minimum password length

        static bool verifyPassword(string password)
        {
            bool isValid = true; //set true by default
            try
            {
                int errorCount = 0; //count number of errors
                var exceptions = new List<Exception>(); //list of exceptions to catch
                if (string.IsNullOrWhiteSpace(password)) //check for null or white space 
                {
                    isValid = false;
                    exceptions.Add(new ArgumentNullException("Password should not be empty\n"));
                    errorCount++;
                }
                if (password.Length < MIN_PASS_LENGTH) //check for minimum password length
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should be longer than 8 characters\n"));
                    errorCount++;
                }
                if (!password.Any(char.IsUpper)) //check if uppercase letter is present 
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one uppercase letter\n"));
                    errorCount++;
                }
                if (!password.Any(char.IsLower)) //check if lowercase letter is present 
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one lowercase letter\n"));
                    errorCount++;
                }
                if (!password.Any(char.IsDigit)) //check digits are present 
                {
                    isValid = false;
                    exceptions.Add(new Exception("Password should have at least one digit\n"));
                    errorCount++;
                }
                if (errorCount != 0) //check for errors
                    throw new AggregateException(exceptions); //throw all the errors in list



            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            return isValid;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your password: ");
            string password;
            password = "";
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
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("");
                        break;
                    }
                }
            } while (true);

            bool isValid = verifyPassword(password); //call verifyPassword function to verify
            if (isValid)
                Console.WriteLine("Password Valid");
            else
                Console.WriteLine("Password Invalid");
        }

    }
}