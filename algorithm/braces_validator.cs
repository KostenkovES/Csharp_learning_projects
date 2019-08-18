using System;
using System.Collections;

namespace BracesValidator
{
    class Program
    {
        static bool IsBracesValid(string bracesString)
        {
            Stack stack = new Stack();
            foreach (int i in bracesString)
            {
                if (i == '(')
                    stack.Push(i);
                if (i == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    stack.Pop();
                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, содержащую скобки для ее проверки ");
            string bracesString = Console.ReadLine();
            Console.WriteLine(IsBracesValid(bracesString));

            Console.ReadLine();
        }
    }
}