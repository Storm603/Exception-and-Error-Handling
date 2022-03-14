using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace T02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", ReadNumber(1, 100)));
        }

        private static List<int> ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();

            int validNumbers = 0;
            int i = 1;

            while(validNumbers < 10)
            {
                string input = Console.ReadLine();

                try
                {
                    if (!int.TryParse(input, out int res))
                    {
                        throw new ArgumentException("Invalid Number!");
                    }

                    if (res <= 1 || res <= i || res >= 100)
                    {
                        throw new ArgumentException($"Your number is not in range {i} - 100!");
                    }

                    if (res > i)
                    {
                        i = res;
                    }

                    validNumbers++;
                    numbers.Add(res);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return numbers;
        }
    }
}
