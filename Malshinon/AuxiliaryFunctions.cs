using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class AuxiliaryFunctions
    {
        public static string ReplaceLastChar(string str, char newChar)
        {
            char[] chars = str.ToCharArray();
            chars[chars.Length - 1] = newChar;
            return new string(chars);
        }
        public static string Input(string inputMessage)
        {

            Console.WriteLine();
            Console.WriteLine(inputMessage + ":\n ");
            string input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        public static string PrintMenu(string title, string[] options)
        {
            int choice = 0;
            Console.WriteLine("\n" + title + ":" +
                "\n");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}:  {options[i]}");
            }
            string input = Input("Enter your choice");

            while (!int.TryParse(input, out choice) && choice < options.Length)
            {
                Console.WriteLine("was not prece correct choice");
                input = Input("Enter your choice");
            }

            return options[choice - 1];
        }

        public static int CreateCode()
        {
            string number = "";
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                number += rand.Next(1, 10).ToString();
            }
            return int.Parse(number);

        }

        public static void AlertMessage()
        {
            Console.WriteLine("מסוכןןןןן");
        }

        public static int WordsLength(string str)
        {
            return str.Split().Length;
        }

        public static bool TimeWindowCheck(DateTime dataTime)
        {
            var timeDifference = DateTime.UtcNow - dataTime.ToUniversalTime();
            return timeDifference.TotalMinutes <= 15;
        }

    }
}
