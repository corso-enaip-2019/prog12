using System;
using System.Collections.Generic;

namespace Test1_Dario_Palmisano
{
    class Program
    {
        static void Main(string[] args)
        {
            IGui consoleGui = new ConsoleGui();

            LoanApplication loanApplication = new LoanApplication(consoleGui);

            loanApplication.Run();
        }

        public List<decimal> createInflationMocks()
        {
            return new List<decimal>()
            {
                1.0m,
                1.5m,
                1.7m,
                1.1m,
                1.9m,
                2.5m,
                3.0m,
                1.9m,
                2.2m,
                3.7m,
            };

        }
    }

    public class LoanApplication
    {
        bool isFixLoan;
        bool isClient;

        IGui _gui;

        public LoanApplication(IGui gui)
        {
            _gui = gui;
        }

        public void Run()
        {
            bool isFixLoan;
            bool isClient;
            ILoanCalculator loanCalculator;


            _gui.PrintNL("### Applicazione di calcolo mutuo ###");
            _gui.PrintNL("");

            decimal loanRequested = _gui.AskForLoan();
            isFixLoan = _gui.IsFixLoan();
            isClient = _gui.IsClient();

            if (isFixLoan)
            {
                loanCalculator = new FixLoanCalculator();
            }
            else
            {
                loanCalculator = new VariableLoanCalculator();
            }

            // Spiacente... non completo!

        }
    } 

    class FixLoanCalculator : ILoanCalculator
    {
        public const decimal FIX_TAX_RATE = 3.5m;
        public decimal InitialAmount { set; get; }
        public decimal FinalAmount { set; get; }
        public bool IsClient { get; set; }
        public decimal MakeCalculation { get; set; }

        public FixLoanCalculator()
        {
            throw new NotImplementedException("Spiacente calcolo non implementato!");
        }
    };

    class VariableLoanCalculator : ILoanCalculator
    {
        public decimal InitialAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public bool IsClient { get; set; }
        public decimal MakeCalculation { get; set; }

        public VariableLoanCalculator()
        {
            throw new NotImplementedException("Spiacente calcolo non implementato!");
        }
    };

    interface ILoanCalculator
    {
        decimal InitialAmount { set; }
        decimal FinalAmount { set; }
        bool    IsClient { set; }
        decimal MakeCalculation { get; }
    }

    class ConsoleGui : IGui
    {
        public decimal AskForLoan()
        {
            decimal loan = 0m;

            Print("Inserire il valore del mutuo richiesto: ");

            do
            {
                if (!decimal.TryParse(Console.ReadLine(), out loan) || loan <= 0m)
                {
                    PrintNL("Il valore del mutuo deve essere un numero > 0. Il valore inserito non e' valido!");
                    PrintNL("");
                }
            }
            while (loan <= 0m);
            PrintNL("");

            return loan;
        }

        public string AskForString(string message)
        {
            string value;

            Print(message);

            value = Console.ReadLine();

            return value;
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintNL(string message)
        {
            Print(message + Environment.NewLine);
        }

        public bool IsFixLoan()
        {
            string isValidString;

            PrintNL("Se si richiede un mutuo a tasso fisso (specificare f)");
            PrintNL("Se si richiede un mutuo a tasso variabile (specificare v)");
            PrintNL("");

            do
            {
                isValidString = AskForString("> ").ToLower();

                if (isValidString != "f" && isValidString != "v")
                {
                    PrintNL("IL valore inserito non e' valido (diverso da f e v). Reinserire");
                    PrintNL("");
                }
            }
            while (isValidString != "f" && isValidString != "v");
            PrintNL("");

            return (isValidString == "f") ? true : false;
        }

        public bool IsClient()
        {
            string isValidString;

            PrintNL("Si e' clienti della banca (si/no)?");

            do
            {
                isValidString = AskForString("> ").ToLower();

                if (isValidString != "si" && isValidString != "no")
                {
                    PrintNL("IL valore inserito non e' valido (diverso da si e no). Reinserire");
                    PrintNL("");
                }
            }
            while (isValidString != "si" && isValidString != "no");
            PrintNL("");

            return (isValidString == "si") ? true : false;
        }
    }

    public interface IGui
    {
        decimal AskForLoan();
        void PrintNL(string message);
        bool IsFixLoan();
        bool IsClient();
    }
}
