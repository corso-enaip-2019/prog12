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

            do
            {
                option = cu.Menu();

                if (option == Option.Quit)
                    break;

                amount = cu.AskAmount();

                if (option == Option.Entry)
                    ba.AddEntry(amount);
                else if (option == Option.Expense)
                    ba.AddExpense(amount);
                else throw new ArgumentOutOfRangeException();
            }
            while (option != Option.Quit);

        }

        static void AddEntryMessage(object o, EventArgsExt e)
        {
            cu.Print($"Added entry amount: {e.Amount} balance {e.Balance}");
        }

        static void AddExpenseMessage(object o, EventArgsExt e)
        {
            cu.Print($"Added expense amount: {e.Amount} balance {e.Balance}");
        }

        static void AccountOnRed(object o, EventArgsExt e)
        {
            cu.Print($"Accoun on red amount: {e.Amount} balance {e.Balance}");
        }
    }

    class EventArgsExt : EventArgs
    {
        public EventArgsExt(decimal amount, decimal balance)
        {
            Amount = amount;
            Balance = balance;
        }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }

    class BankAccount
    {
        public BankAccount()
        {
            Deposit = 0m;
        }

        public decimal Deposit { get; private set; }
        

        public delegate void BankActivity(object sender, EventArgsExt e);
        public event BankActivity EntryAdded;
        public event BankActivity ExpenseAdded;
        public event BankActivity AccountOnRed;

//        public delegate void EventHandler(object sender, EventArgs e);
//        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

        public void AddEntry(decimal amount)
        {
            Deposit += amount;

            if (EntryAdded != null)
                EntryAdded.Invoke(this, new EventArgsExt(amount, Deposit));
        }

        public void AddExpense(decimal amount)
        {
            decimal balance = Deposit - amount;

            if (Deposit > 0m)
            {
                if (balance < 0)
                {
                    if (AccountOnRed != null)
                        AccountOnRed.Invoke(this, new EventArgsExt(amount, balance));
                }
                else
                {
                    Deposit = balance;

                    if (ExpenseAdded != null)
                        ExpenseAdded.Invoke(this, new EventArgsExt(amount, balance));
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
                Environment.NewLine + "Type: n for entry, x for expense, q for quit");

            do
            {
                input = Console.ReadKey().Key.ToString().ToLower();

                Console.WriteLine();

                if (input != "n" && input != "x" && input != "q")
                    Console.WriteLine("The entered option does not exist. Please try again...");
            }
            while (input != "n" && input != "x" && input != "q");

            switch (input)
            {
                case "n":
                    return Option.Entry;
                    break;
                case "x":
                    return Option.Expense;
                    break;
                case "q":
                    return Option.Quit;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;

            }
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


    enum Option { Entry, Expense, Quit };


}
