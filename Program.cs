using System;
using System.Text;
using System.Collections.Generic;

namespace PhoneKeypadProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Phone Keypad Text Converter");
                Console.WriteLine("==========================");


                RunTestCases();


                Console.WriteLine("\nInteractive Mode:");
                Console.WriteLine("Enter your input (must end with #):");
                Console.WriteLine("Example: 4433555 555666# -> HELLO");

                string? userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    string result = PhoneKeypad.OldPhonePad(userInput);
                    Console.WriteLine($"\nYour input: {userInput}");
                    Console.WriteLine($"Output: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void RunTestCases()
        {
            Console.WriteLine("\nRunning Test Cases:");
            RunTest("33#", "E");
            RunTest("227*#", "B");
            RunTest("4433555 555666#", "HELLO");
            RunTest("8 88777444666*664#", "STRONG");
            RunTest("7 555 33 2 7777 33 0 44 444 777 33 0 6 33#", "PLEASE HIRE ME");
            Console.WriteLine("\nTest Cases Completed.");
        }

        static void RunTest(string input, string expected)
        {
            try
            {
                string result = PhoneKeypad.OldPhonePad(input);
                Console.WriteLine($"\nInput: {input}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"Status: {(result == expected ? "✓ PASSED" : "✗ FAILED")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test Failed - {ex.Message}");
            }
        }
    }

    public class PhoneKeypad
    {
        private static readonly Dictionary<char, string> keypadMapping = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            {
                throw new ArgumentException("Input must not be empty and must end with #");
            }

            var result = new StringBuilder();
            var currentChar = ' ';
            var pressCount = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                char digit = input[i];

                if (digit == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                    currentChar = ' ';
                    pressCount = 0;
                    continue;
                }

                if (digit == ' ' || digit != currentChar)
                {
                    currentChar = digit;
                    pressCount = 1;
                }
                else
                {
                    pressCount++;
                }

                if (keypadMapping.ContainsKey(digit))
                {
                    string chars = keypadMapping[digit];

                    if (digit == currentChar && pressCount > 1 && result.Length > 0)
                    {
                        result.Length--;
                    }

                    int charIndex = (pressCount - 1) % chars.Length;
                    result.Append(chars[charIndex]);
                }
            }

            return result.ToString();
        }
    }
}