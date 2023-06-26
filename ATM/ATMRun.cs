using System;
using System.IO;

namespace ATM;
public class ATMStart
{
    private string accountFile;

    public ATMStart(string accountFile)
    {
        this.accountFile = accountFile;
    }

    public static void ATMRUN()
    {
        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the ATM!");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Exit");
            Console.Write("Please enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    CheckBalance();
                    break;
                case 2:
                    Console.Clear();
                    DepositMoney();
                    break;
                case 3:
                    Console.Clear();
                    WithdrawMoney();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private static void CheckBalance()
    {

        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        Console.WriteLine("Checking Balance");
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        if (AccountExists(accountNumber))
        {
            string[] lines = File.ReadAllLines(accountFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts[0] == accountNumber)
                {
                    Console.WriteLine("Hello, " + parts[1]);
                    Console.WriteLine("Your balance is: $" + parts[2]);
                    return;
                }
            }

            Console.WriteLine("Error: Account not found.");
        }
        else
        {
            Console.WriteLine("Error: Account not found.");
        }
     
        
    }


    private static void DepositMoney()
    {
        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        Console.WriteLine("Depositing Money");
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        if (AccountExists(accountNumber))
        {
            Console.Write("Enter the amount to deposit: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid amount. Please try again.");
                return;
            }

            string[] lines = File.ReadAllLines(accountFile);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts[0] == accountNumber)
                {
                    decimal currentBalance = Convert.ToDecimal(parts[2]);
                    currentBalance += amount;
                    parts[2] = currentBalance.ToString();
                    lines[i] = string.Join(",", parts);
                    File.WriteAllLines(accountFile, lines);
                    Console.WriteLine("Hello, " + parts[1]);
                    Console.WriteLine("Deposit successful. Your new balance is: $" + currentBalance);
                    return;
                }
            }

            Console.WriteLine("Error: Account not found.");
        }
        else
        {
            Console.WriteLine("Error: Account not found.");
        }
       
    }

    private static void WithdrawMoney()
    {
        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        Console.WriteLine("Withdrawing Money");
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        if (AccountExists(accountNumber))
        {
            Console.Write("Enter the amount to withdraw: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid amount. Please try again.");
                return;
            }

            string[] lines = File.ReadAllLines(accountFile);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts[0] == accountNumber)
                {
                    decimal currentBalance = Convert.ToDecimal(parts[2]);

                    if (currentBalance >= amount)
                    {
                        currentBalance -= amount;
                        parts[2] = currentBalance.ToString();
                        lines[i] = string.Join(",", parts);
                        File.WriteAllLines(accountFile, lines);
                        Console.WriteLine("Hello, " + parts[1]);
                        Console.WriteLine("Withdrawal successful. Your new balance is: $" + currentBalance);
                    }
                    else
                    {
                        Console.WriteLine("Error: Insufficient balance.");
                    }

                    return;
                }
            }

            Console.WriteLine("Error: Account not found.");
        }
        else
        {
            Console.WriteLine("Error: Account not found.");
        }
      
    }

    private static bool AccountExists(string accountNumber)
    {
        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        if (File.Exists(accountFile))
        {
            string[] lines = File.ReadAllLines(accountFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts[0] == accountNumber)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static void Main()
    {
        string accountFile = @"C:\Users\GIA\Desktop\ATM.txt";
        ATMStart atm = new ATMStart(accountFile);
    }
    
}
