using System;
using System.Linq;

namespace T04.SumofIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    if (int.TryParse(input[i], out int rezz))
                    {
                        sum += rezz;
                        continue;
                    }

                    if (long.TryParse(input[i], out long res))
                    {
                        throw new OverflowException($"The element '{input[i]}' is out of range!");
                    }

                    if (!double.TryParse(input[i], out double rez))
                    {
                        throw new FormatException($"The element '{input[i]}' is in wrong format!");
                    }

                    if (input[i] is string)
                    {
                        throw new FormatException($"The element '{input[i]}' is in wrong format!");
                    }
                }
                catch (OverflowException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
