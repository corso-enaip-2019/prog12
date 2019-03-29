using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            int numeroPartitaIVA;
            bool inserimentoValido;
            decimal fattura;
            decimal spesa;

            VatNumberNormal vatNumberNormal;
            VatNumberSimple vatNumberSimple;

            List<object> VatNumberList = new List<object>();
            object partitaIVATrovata = null;

            for (int code = 1; code <= 10; code++)
            { 
                vatNumberNormal = new VatNumberNormal();
                vatNumberNormal.Code = 1;
                vatNumberNormal.Bills = new List<decimal>();
                vatNumberNormal.Bills.Add(new Random().Next() % 10000);
                vatNumberNormal.Bills.Add(new Random().Next() % 10000);
                vatNumberNormal.Bills.Add(new Random().Next() % 10000);
                vatNumberNormal.Expenses = new List<decimal>();
                vatNumberNormal.Expenses.Add(new Random().Next() % 3000);
                vatNumberNormal.Expenses.Add(new Random().Next() % 3000);

                VatNumberList.Add(vatNumberNormal);

                vatNumberSimple = new VatNumberSimple();
                vatNumberSimple.Code = 1;
                vatNumberSimple.Bills = new List<decimal>();
                vatNumberSimple.Bills.Add(new Random().Next() % 10000);
                vatNumberSimple.Bills.Add(new Random().Next() % 10000);
                vatNumberSimple.Bills.Add(new Random().Next() % 10000);

                VatNumberList.Add(vatNumberSimple);
            }

            Console.WriteLine(VatNumberList[0].GetType());


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
                            // Inserimento Partita IVA Begin
                            do
                            {
                                Console.WriteLine("Inserisci il numero Partita IVA");

                                inserimentoValido = int.TryParse(Console.ReadLine(), out numeroPartitaIVA);

                                if (!inserimentoValido)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                                else
                                {
                                    inserimentoValido = false;

                                    foreach (object o in VatNumberList)
                                    {
                                        if (numeroPartitaIVA == ((VatNumberSimple)o).Code)
                                        {
                                            inserimentoValido = true;
                                            partitaIVATrovata = o;
                                            break;
                                        }
                                    }

                                    if (!inserimentoValido)
                                    {
                                        Console.WriteLine("La partita IVA inserita non esiste nel database! Riprova...");
                                    }
                                }

                            }
                            while (!inserimentoValido);
                            // Inserimento Partita IVA End

                            // Inserimento fattura Begin
                            do
                            {
                                Console.WriteLine("Inserisci il valore della fattura");

                                inserimentoValido = decimal.TryParse(Console.ReadLine(), out fattura);

                                if (!inserimentoValido)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                            }
                            while (!inserimentoValido);
                            // Inserimento fattura End

                            // Aggiungi fattura a Partita Iva Begin
                            if (partitaIVATrovata != null) {
                                if (partitaIVATrovata is VatNumberNormal)
                                {
                                    ((VatNumberNormal) partitaIVATrovata).Bills.Add(fattura);
                                }
                                else
                                {
                                    ((VatNumberSimple)partitaIVATrovata).Bills.Add(fattura);
                                }
                            }
                            // Aggiungi fattura a Partita Iva End
                        }
                        break;
                    case 2: // Aggiungi spesa
                        {
                            // Inserimento Partita IVA Begin
                            do
                            {
                                Console.WriteLine("Inserisci il numero Partita IVA");

                                inserimentoValido = int.TryParse(Console.ReadLine(), out numeroPartitaIVA);

                                if (!inserimentoValido)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                                else
                                {
                                    inserimentoValido = false;

                                    foreach (object o in VatNumberList)
                                    {

                                        if (numeroPartitaIVA == ((VatNumberSimple)o).Code)
                                        {
                                            inserimentoValido = true;
                                            partitaIVATrovata = o;
                                            break;
                                        }
                                    }

                                    if (!inserimentoValido)
                                    {
                                        Console.WriteLine("La partita IVA inserita non esiste nel database! Riprova...");
                                    }
                                }

                            }
                            while (!inserimentoValido);
                            // Inserimento Partita IVA End

                            // Inserimento spesa Begin
                            do
                            {
                                Console.WriteLine("Inserisci il valore della spesa");

                                inserimentoValido = decimal.TryParse(Console.ReadLine(), out spesa);

                                if (!inserimentoValido)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                            }
                            while (!inserimentoValido);
                            // Inserimento spesa End

                            // Aggiungi spesa a Partita Iva Begin
                            if (partitaIVATrovata != null)
                            {
                                if (partitaIVATrovata is VatNumberNormal)
                                {
                                    ((VatNumberNormal)partitaIVATrovata).Expenses.Add(spesa);
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

                                inserimentoValido = int.TryParse(Console.ReadLine(), out numeroPartitaIVA);

                                if (!inserimentoValido)
                                {
                                    Console.WriteLine("Il valore inserito non e' valido! Riprova...");
                                }
                                else
                                {
                                    inserimentoValido = false;

                                    foreach (object o in VatNumberList)
                                    {
                                        if (numeroPartitaIVA == ((VatNumberSimple)o).Code)
                                        {
                                            inserimentoValido = true;
                                            partitaIVATrovata = o;
                                            break;
                                        }
                                    }

                                    if (!inserimentoValido)
                                    {
                                        Console.WriteLine("La partita IVA inserita non esiste nel database! Riprova...");
                                    }
                                }

                            }
                            while (!inserimentoValido);
                            // Inserimento Partita IVA End

                            // Calcola guadagno e tasse Begin
                            if (partitaIVATrovata != null)
                            {
                                if (partitaIVATrovata is VatNumberSimple)
                                {
                                    VatNumberSimple vns = ((VatNumberSimple)partitaIVATrovata);
                                    decimal totalBill = 0m;
                                    decimal tasse = 0m;

                                    foreach (decimal b in vns.Bills)
                                    {
                                        totalBill += b;
                                    }

                                    tasse = (totalBill * 78 / 100) * 15 / 100;

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vns.Code}");
                                    Console.WriteLine($"Totale fatture {totalBill}");
                                    Console.WriteLine($"Tasse          {tasse}");
                                }
                                else
                                {
                                    // VatNumberNormal

                                    VatNumberNormal vnn = ((VatNumberNormal)partitaIVATrovata);

                                    decimal IVA;
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

                                    IVA = profit * 22 / 100;
                                    IRPEF = IVA * 23 / 100;

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vnn.Code}");
                                    Console.WriteLine($"Totale fatture {totalBill}");
                                    Console.WriteLine($"Totale spese   {totalExpenses}");
                                    Console.WriteLine($"Profitto {profit}");
                                    Console.WriteLine($"IVA {IVA}");
                                    Console.WriteLine($"IRPEF {IRPEF}");
                                }
                            }
                            // Calcola guadagno e tasse End
                        }
                        break;
                    case 4: // Lista le Partite IVA
                        {
                            foreach (object o in VatNumberList)
                            {
                                if (o is VatNumberSimple)
                                {
                                    VatNumberSimple vns = ((VatNumberSimple)o);

                                    Console.WriteLine("Partita IVA Semplice");
                                    Console.WriteLine($"Numero {vns.Code}");
                                    foreach (decimal b in vns.Bills)
                                    {
                                        Console.WriteLine($"Fattura: {b}");
                                    }
                                    
                                }
                                else
                                {
                                    VatNumberNormal vnn = ((VatNumberNormal)o);

                                    Console.WriteLine("Partita IVA Normale");
                                    Console.WriteLine($"Numero {vnn.Code}");
                                    foreach (decimal b in vnn.Bills)
                                    {
                                        Console.WriteLine($"Fattura: {b}");
                                    }
                                    foreach (decimal e in vnn.Expenses)
                                    {
                                        Console.WriteLine($"Spesa: {e}");
                                    }
                                }
                            }

                        }
                        break;
                    default:
                        {
                        }
                        break;
                 }
                // Selection operation End


            } while (option != '5');
        }
    }

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


}
