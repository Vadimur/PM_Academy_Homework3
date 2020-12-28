using System;
using System.Collections.Generic;

namespace Task_1._4
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.4 Brackets pairing test";
        private static string programRules = "It is an application that will validate parenthesis sequence\n";
        
        static void Main(string[] args)
        {
            Console.WriteLine(programDescription);
            Console.WriteLine(author);
            Console.WriteLine(programRules);
            string sequence;
            do
            {
                Console.WriteLine("Enter sequence");
                sequence = Console.ReadLine();
            } while (string.IsNullOrEmpty(sequence));

            int errorPosition = ValidateSequence(sequence);
            string result = errorPosition == -1 ? "valid" : $"invalid. Error at position {errorPosition}";
            Console.WriteLine($"The sequence you entered is {result}");
        }

        private static int ValidateSequence(string sequence)
        {
            var brackets = new Stack<CharacterPosition>();
            for (int i = 0; i < sequence.Length; i++)
            {
                char character = sequence[i];
                switch (character)
                {
                    case '(':
                        brackets.Push(new CharacterPosition(')', i));
                        break;
                    case '[':
                        brackets.Push(new CharacterPosition(']', i));
                        break;
                    case '{':
                        brackets.Push(new CharacterPosition('}', i));
                        break;
                    case '<':
                        brackets.Push(new CharacterPosition('>', i));
                        break;
                    case ')':
                    case ']':
                    case '}':
                    case '>':
                        if (brackets.Count == 0 || brackets.Pop().Character != character)
                            return i; 
                        break;
                }
            }

            if (brackets.Count != 0)
                return brackets.Pop().Position;
            
            return -1;
        }
    }
}