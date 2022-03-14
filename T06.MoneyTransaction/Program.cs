using System;
using System.Collections.Generic;

namespace T06.MoneyTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accountInformations = new Dictionary<int, double>();

            string[] accountBalanceInput = Console.ReadLine().Split(".");

            for (int i = 0; i < accountBalanceInput.Length; i++)
            {
                string[] splittedInfo = accountBalanceInput[i].Split("-");

                int accountNumber = int.Parse(splittedInfo[0]);
                double accountBalance = double.Parse(splittedInfo[1]);

                if (!accountInformations.ContainsKey(accountNumber))
                {
                    accountInformations.Add(accountNumber, accountBalance);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitInfo = input.Split();

                string command = splitInfo[0];
                int accountNumber = int.Parse(splitInfo[1]);
                double sumToOperateWith = double.Parse(splitInfo[2]);

                try
                {
                    if (!accountInformations.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (command == "Deposit")
                    {
                        accountInformations[accountNumber] += sumToOperateWith;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accountInformations[accountNumber]}");
                    }
                    else if (command == "Withdraw")
                    {
                        if (accountInformations[accountNumber] < sumToOperateWith)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        accountInformations[accountNumber] -= sumToOperateWith;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accountInformations[accountNumber]}");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                input = Console.ReadLine();
            }
        }
    }
}
