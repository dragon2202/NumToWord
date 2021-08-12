﻿using System;

namespace Numbers_to_Words
{
    class Program
    {
        static string[] OneToNineteen = new string[] { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        static string[] TwentyToNinety = new string[] { "", "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        static string[] testCaseArray = new string[] { "0", "255", "32767", "123456789", "2147483647", "1000000000", "4284967295", "9223372036854775807", "18446744073709551615", "99999999999999999999" };

        static void testCase() {
            for (int i = 0; i < testCaseArray.Length; i++) {
                try
                {
                    Console.WriteLine(convert_to_words(ulong.Parse(testCaseArray[i])));
                } 
                catch (System.OverflowException)
                {
                    Console.WriteLine("Length over 19 is not supported.");
                }
            }
        }

        static string numToWords(int num, string word) 
        {
            string str = "";
            //If number is more than 19, divide it by tens and than ones
            if (num > 19)
            {
                str += TwentyToNinety[num / 10] + OneToNineteen[num % 10];
            }
            else //One through Nineteen, as the english words from 1-19 are unique
            {
                str += OneToNineteen[num];
            }
            // If num is multiple of thousands
            if (num != 0) 
            {
                str += word;
            }

            return str;
        }

        static string convert_to_words(ulong num) {
            string wordRepresentation = "";

            // 1 to 99 Quintillion
            wordRepresentation += numToWords((int)((num / 1000000000000000000) % 100), "Quintillion ");
            // 1 to 9 Hundred Quadrillion
            wordRepresentation += numToWords((int)((num / 100000000000000000) % 10), "Hundred ");
            // 1 to 99 Quadrillion
            wordRepresentation += numToWords((int)((num / 1000000000000000) % 100), "Quadrillion ");
            // 1 to 9 Hundred Trillion
            wordRepresentation += numToWords((int)((num / 10000000000000) % 10), "Hundred ");
            // 1 to 99 Trillion
            wordRepresentation += numToWords((int)((num / 1000000000000) % 100), "Trillion ");
            // 1 to 9 Hundred Billion
            wordRepresentation += numToWords((int)((num / 100000000000) % 10), "Hundred ");
            // 1 to 99 Billion
            wordRepresentation += numToWords((int)((num / 1000000000) % 100), "Billion ");
            // 1 to 9 Hundred Million
            wordRepresentation += numToWords((int)((num / 100000000) % 10), "Hundred ");
            // 1 to 99 Million
            wordRepresentation += numToWords((int)((num / 1000000) % 100), "Million ");
            // 1 to 9 Hundred Thousand
            wordRepresentation += numToWords((int)((num / 100000) % 10), "Hundred ");
            // 1 to 99 Thousand 
            wordRepresentation += numToWords((int)((num / 1000) % 100), "Thousand ");
            // 1 to 9 Hundred
            wordRepresentation += numToWords((int)((num / 100) % 10), "Hundred ");
            // 1 to 99
            wordRepresentation += numToWords((int)(num % 100), "");

            return wordRepresentation;
        }

        static void Main(string[] args)
        {
            string number = "";
            try
            {
                number = args[0];
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid input: Empty String.");
                return;
            }

            //Base Cases
            if (number == "-t")
            {
                testCase();
                return;
            }
            if (number.Length > 19)
            {
                Console.WriteLine("Length over 19 is not supported.");
                return;
            }
            if (number[0] == '-')
            {
                Console.WriteLine("Invalid input: Negative sign not accepted");
                return;
            }
            if (number.Length == 1 && ulong.Parse(number) == 0)
            {
                Console.WriteLine("Zero");
                return;
            }
            if (!ulong.TryParse(number, out ulong result))
            {
                Console.WriteLine("Invalid input: Not a Number.");
                return;
            }


            Console.WriteLine(convert_to_words(ulong.Parse(number)));

            Console.WriteLine("Enter any key to Quit");
            Console.ReadKey();

        }
    }
}
