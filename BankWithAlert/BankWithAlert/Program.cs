using System;

namespace BankWithAlert
{
    class Program
    {
        static BankAccount ba; 
        static ConsoleUI cu;

        static void Main(string[] args)
        {
            decimal amount;
            Option option;

            ba = new BankAccount();
            cu = new ConsoleUI();

            ba.EntryAdded += AddEntryMessage;
            ba.ExpenseAdded += AddExpenseMessage;
            ba.AccountOnRed += AccountOnRed;
                
            while (true)
            {
                option = cu.Menu();
                amount = cu.AskAmount();

                if (option == Option.Entry)
                    ba.AddEntry(amount);
                else if (option == Option.Expense)
                    ba.AddExpense(amount);
                else throw new ArgumentOutOfRangeException();
            }
        }

        static void AddEntryMessage()
        {
            cu.Print("Added entry");
        }

        static void AddExpenseMessage()
        {
            cu.Print("Added expense");
        }

        static void AccountOnRed()
        {
            cu.Print("Accoun on red");
        }
    }

    class BankAccount
    {
        public BankAccount()
        {
            Deposit = 0m;
        }

        public decimal Deposit { get; private set; }
        

        public delegate void BankActivity();
        public event BankActivity EntryAdded;
        public event BankActivity ExpenseAdded;
        public event BankActivity AccountOnRed;


        public void AddEntry(decimal amount)
        {
            Deposit += amount;

            if (EntryAdded != null)
                EntryAdded.Invoke();
        }

        public void AddExpense(decimal amount)
        {
            decimal balance = Deposit - amount;

            if (Deposit > 0m)
            {
                if (balance < 0)
                {
                    if (AccountOnRed != null)
                        AccountOnRed.Invoke();
                }
                else
                {
                    Deposit = balance;

                    if (ExpenseAdded != null)
                        ExpenseAdded.Invoke();
                }
            }
        }
    }

    class ConsoleUI
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        public Option Menu()
        {
            string input;
            Console.WriteLine("Do you want to add an entry or an expense?" +
                Environment.NewLine + "Type: n for entry, x for expense");

            do
            {
                input = Console.ReadKey().Key.ToString().ToLower();

                Console.WriteLine();

                if (input != "n" && input != "x")
                    Console.WriteLine("The entered option does not exist. Please try again...");
            }
            while (input != "n" && input != "x");

            if (input == "n")
                return Option.Entry;
            else if (input == "x")
                return Option.Expense;
            else throw new ArgumentOutOfRangeException();
        }

        public decimal AskAmount()
        {
            bool isValid;
            decimal amount;
            Console.Write("Enter the amount: ");

            do
            {
                isValid = decimal.TryParse(Console.ReadLine(), out amount) && amount > 0m;

                if (!isValid)
                    Console.WriteLine("The enetered value is invalid. Please try again...");
            }
            while (!isValid);

            return amount;
        }
    }


    enum Option { Entry, Expense };


}
