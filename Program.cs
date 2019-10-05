using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("================================================");
            Console.WriteLine("To generate a password, insert 3 strings that will be used to generate");
            Console.WriteLine("Insert string for first input");
            var input1 = Console.ReadLine();

            Console.WriteLine("Insert string for second input");
            var input2 = Console.ReadLine();

            Console.WriteLine("Insert string for third input");
            var input3 = Console.ReadLine();

            var response = GeneratePassword.generatePassword(input1, input2, input3);

            if (response != null)
            {
                Console.WriteLine("The Generated Password is: " +response);
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Failed to generate password");
                Console.ReadLine();
            }

        }
    }
}
