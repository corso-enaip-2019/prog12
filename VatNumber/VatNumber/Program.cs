using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatNumber
{
    class VatNumberNormal
    {
        public int Code;
        public List<decimal> Bills;
        public List<decimal> Expenses;
    }

    class VatNumberSimple
    {
        public int Code;
        public List<decimal> Bills;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int option;
            int VATcode;
            bool isValid;
            decimal bill;
            decimal spesa;

            VatNumberNormal vatNumberNormal;
            VatNumberSimple vatNumberSimple;

            List<object> VatNumbers = new List<object>();
            object FoundVATNumber = null;

            // Inizializzazione Begin
            vatNumberNormal = new VatNumberNormal();
            vatNumberNormal.Code = 1;
            vatNumberNormal.Bills = new List<decimal>();
            vatNumberNormal.Bills.Add(7500m);
            vatNumberNormal.Bills.Add(5000m);
            vatNumberNormal.Bills.Add(2500m);
            vatNumberNormal.Expenses = new List<decimal>();
            vatNumberNormal.Expenses.Add(1000m);
            vatNumberNormal.Expenses.Add(500m);

            VatNumbers.Add(vatNumberNormal);

            vatNumberSimple = new VatNumberSimple();
            vatNumberSimple.Code = 2;
            vatNumberSimple.Bills = new List<decimal>();
            vatNumberSimple.Bills.Add(7000m);
            vatNumberSimple.Bills.Add(3000m);

            VatNumbers.Add(vatNumberSimple);
/*
            for (int code = 2; code <= 10; code++)
            {
                vatNumberNormal = new VatNumberNormal();
                vatNumberNormal.Code = code;
                vatNumberNormal.Bills = new List<decimal>();
                vatNumberNormal.Bills.Add(new Random().Next() % 10000m);
                vatNumberNormal.Bills.Add(new Random().Next() % 10000m);
                vatNumberNormal.Bills.Add(new Random().Next() % 10000m);
                vatNumberNormal.Expenses = new List<decimal>();
                vatNumberNormal.Expenses.Add(new Random().Next() % 3000m);
                vatNumberNormal.Expenses.Add(new Random().Next() % 3000m);

                VatNumbers.Add(vatNumberNormal);

                vatNumberSimple = new VatNumberSimple();
                vatNumberSimple.Code = code + 10;
                vatNumberSimple.Bills = new List<decimal>();
                vatNumberSimple.Bills.Add(new Random().Next() % 10000m);
                vatNumberSimple.Bills.Add(new Random().Next() % 10000m);
                vatNumberSimple.Bills.Add(new Random().Next() % 10000m);

                VatNumbers.Add(vatNumberSimple);
            }
*/
            // Inizializzazione End

            do
            {

                // Menu Begin
                Console.WriteLine("Menu");
                Console.WriteLine();
                Console.WriteLine("1 Aggiungi fattura");
                Console.WriteLine("2 Aggiungi spesa");
                Console.WriteLine("3 Calcola guadagno e tasse");
                Console.WriteLine("4 Lista le Partite IVA");
                Console.WriteLine("5 Esci");

                do
                {

                    option = Console.Read() - '0';

                    // flush the \r\n in the buffer
                    Console.Read();
                    Console.Read();

                    if (option < 1 || option > 5)
                    {
                        Console.WriteLine("Entry di menu non valida. Riprova");
                    }
                }
                while (option < 1 || option > 5);

                // Menu End

                // Selection operation Begin
                switch (option)
                {
                    case 1: // Aggiungi fattura
                        {
                            VATcode = AskVATCode("Inserisci il numero Partita IVA");

                            // Inserimento fattura Begin
                            do
                            {
                                Console.WriteLine("Inserisci il valore della fattura");

                                isValid = decimal.TryParse(Console.ReadLine(), out bill);

                                if (!isValid)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                            }
                            while (!isValid);
                            // Inserimento fattura End

                            // Aggiungi fattura a Partita Iva Begin

                            AddBill(VatNumbers, FoundVATNumber, bill);

                            // Aggiungi fattura a Partita Iva End
                        }
                        break;

                    case 2: // Aggiungi spesa
                        {
                            // Inserimento Partita IVA Begin


                            do
                            {
                                Console.WriteLine("Inserisci il numero Partita IVA");

                                isValid = int.TryParse(Console.ReadLine(), out VATcode);

                                if (!isValid)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                                else
                                {
                                    FoundVATNumber = SearchVATNumber(VatNumbers, VATcode);

                                    isValid = FoundVATNumber != null;
                                }
                            }
                            while (!isValid);
                            // Inserimento Partita IVA End

                            // Aggiungi spesa a Partita Iva Begin


                            if (FoundVATNumber != null)
                            {
                                if (FoundVATNumber is VatNumberNormal)
                                {
                                    // Inserimento spesa Begin
                                    do
                                    {
                                        Console.WriteLine("Inserisci il valore della spesa");

                                        isValid = decimal.TryParse(Console.ReadLine(), out spesa);

                                        if (!isValid)
                                        {
                                            Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                        }
                                    }
                                    while (!isValid);
                                    // Inserimento spesa End

                                    AddExpense(VatNumbers, FoundVATNumber, expense);
                                }
                                else
                                {
                                    Console.WriteLine("Errore: Non e' possibile addebitare una spesa ad una La partita IVA semplice!");
                                }
                            }
                            // Aggiungi spesa a Partita Iva End
                        }
                        break;

                    case 3: // Calcola guadagno e tasse
                        {
                            // Inserimento Partita IVA Begin
                            do
                            {
                                Console.WriteLine("Inserisci il numero Partita IVA");

                                isValid = int.TryParse(Console.ReadLine(), out VATcode);

                                if (!isValid)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                                else
                                {
                                    FoundVATNumber = SearchVATNumber(VatNumbers, VATcode);

                                    isValid = FoundVATNumber != null;
                                }

                            }
                            while (!isValid);
                            // Inserimento Partita IVA End

                            // Calcola guadagno e tasse Begin
                            if (FoundVATNumber != null)
                            {
                                Console.WriteLine();

                                if (FoundVATNumber is VatNumberSimple)
                                {
                                    VatNumberSimple vns = ((VatNumberSimple)FoundVATNumber);
                                    decimal totalBill = 0m;
                                    decimal taxes = 0m;

                                    foreach (decimal b in vns.Bills)
                                    {
                                        totalBill += b;
                                    }

                                    taxes = (totalBill * 78m / 100m) * 15m / 100m;

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vns.Code}");
                                    Console.WriteLine($"Totale fatture {totalBill}");
                                    Console.WriteLine($"Profitto       {totalBill - taxes}");
                                    Console.WriteLine($"Tasse          {taxes}");
                                }
                                else
                                {
                                    // VatNumberNormal

                                    VatNumberNormal vnn = ((VatNumberNormal)FoundVATNumber);

                                    decimal VAT;
                                    decimal IRPEF;
                                    decimal profit;
                                    decimal totalBill = 0m;
                                    decimal totalExpenses = 0m;

                                    foreach (decimal b in vnn.Bills)
                                    {
                                        totalBill += b;
                                    }
                                    foreach (decimal e in vnn.Expenses)
                                    {
                                        totalExpenses += e;
                                    }

                                    profit = totalBill - totalExpenses;

                                    VAT = profit * 22m / 100m;

                                    profit -= VAT;

                                    IRPEF = profit * 23m / 100m;

                                    profit -= IRPEF;

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vnn.Code}");
                                    Console.WriteLine($"Totale fatture {totalBill}");
                                    Console.WriteLine($"Totale spese   {totalExpenses}");
                                    Console.WriteLine($"Profitto {profit}");
                                    Console.WriteLine($"IVA {VAT}");
                                    Console.WriteLine($"IRPEF {IRPEF}");
                                }

                                Console.WriteLine();
                            }
                            // Calcola guadagno e tasse End
                        }
                        break;

                    case 4: // Lista le Partite IVA
                        {
                            foreach (object o in VatNumbers)
                            {
                                Console.WriteLine();

                                if (o is VatNumberSimple)
                                {
                                    VatNumberSimple vns = ((VatNumberSimple) o);

                                    Console.WriteLine("Partita IVA Semplice");
                                    Console.WriteLine($"Numero {vns.Code}");
                                    foreach (decimal b in vns.Bills)
                                    {
                                        Console.WriteLine($"Fattura: {b}");
                                    }
                                }
                                else
                                {
                                    VatNumberNormal vnn = ((VatNumberNormal) o);

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vnn.Code}");
                                    foreach (decimal b in vnn.Bills)
                                    {
                                        Console.WriteLine($"Fattura: {b}");
                                    }
                                    foreach (decimal e in vnn.Expenses)
                                    {
                                        Console.WriteLine($"Spesa:   {e}");
                                    }
                                }

                                Console.WriteLine();
                            }
                        }
                        break;

                    default:
                        {
                        }
                        break;
                 }
                // Selection operation End


            } while (option != 5);
        }



        static int AskVATCode(string message) {                             
            do
            {
                //                Console.WriteLine("Inserisci il numero Partita IVA");
                Console.WriteLine(message);

                isValid = int.TryParse(Console.ReadLine(), out VATcode);

                if (!isValid)
                {
                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                }
                else
                {
                    FoundVATNumber = SearchVATNumber(VatNumbers, VATcode);

isValid = FoundVATNumber != null;
                }
            }
            while (!isValid);
            // Inserimento Partita IVA End
        }

        static void AddExpense(List<object> VatNumbers, object FoundVATNumber, decimal expense)
        {
            if (VatNumbers == null)
            {
                return;
            }
            else if (FoundVATNumber == null)
            {
                return;
            }
            else if (FoundVATNumber is VatNumberNormal)
            {
                ((VatNumberNormal)FoundVATNumber).Expenses.Add(expense);
            }
            else
            {
                Console.WriteLine("Errore: Non e' possibile addebitare una spesa ad una La partita IVA semplice!");
            }
        }

        static void AddBill(List<object> VatNumbers, object FoundVATNumber, decimal bill)
        {
            if (VatNumbers == null)
            {
                return;
            }
            else if (FoundVATNumber ==null)
            {
                return;
            }
            else if (FoundVATNumber is VatNumberNormal)
            {
                ((VatNumberNormal)FoundVATNumber).Bills.Add(bill);
            }
            else
            {
                ((VatNumberSimple)FoundVATNumber).Bills.Add(bill);
            }
            
        }

        static object SearchVATNumber(List<object> VatNumbers, int VATcode)
        {
            object FoundVATNumber = null;

            foreach (object o in VatNumbers)
            {
                int code;

                if (o is VatNumberSimple)
                {
                    code = ((VatNumberSimple)o).Code;
                }
                else
                {
                    code = ((VatNumberNormal)o).Code;
                }

                if (VATcode == code)
                {
                    FoundVATNumber = o;
                    break;
                }
            }

            if (FoundVATNumber == null)
            {
                Console.WriteLine("La partita IVA inserita non esiste nel database! Riprova...");
            }

            return FoundVATNumber;
        }
    }
}
