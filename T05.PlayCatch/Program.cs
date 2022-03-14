using System;
using System.Linq;

namespace T05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int caughtExceptions = 0;

            while (caughtExceptions < 3)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];

                try
                {
                    if (!int.TryParse(command[1], out int result))
                    {
                        throw new FormatException("The variable is not in the correct format!");
                    }

                    int indexOne = int.Parse(command[1]);

                    if (indexOne < 0 || indexOne >= array.Length)
                    {
                        throw new IndexOutOfRangeException("The index does not exist!");
                    }

                    if (action == "Replace" || action == "Print")
                    {
                        if (!int.TryParse(command[2], out int rezult))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        int indexTwo = int.Parse(command[2]);

                        if (action == "Replace")
                        {
                            array[indexOne] = indexTwo;
                        }
                        else if (action == "Print")
                        {
                            if (indexTwo < 0 || indexTwo >= array.Length)
                            {
                                throw new IndexOutOfRangeException("The index does not exist!");
                            }

                            for (int i = indexOne; i <= indexTwo; i++)
                            {
                                if (i < indexTwo)
                                {
                                    Console.Write($"{array[i]}, ");
                                }
                                else
                                {
                                    Console.WriteLine($"{array[i]}");
                                }
                                
                            }
                        }
                    }
                    else if (action == "Show")
                    {
                        Console.WriteLine(array[indexOne]);
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    caughtExceptions++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    caughtExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
