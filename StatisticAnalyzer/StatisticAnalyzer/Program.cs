using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputOutput inputOutput = new ConsoleIO();
            StatisticCalculator statisticCalculator = new StatisticCalculator();
            StatisticAnalyzer statisticAnalyzer = new StatisticAnalyzer(statisticCalculator, inputOutput);

            statisticAnalyzer.Run();

            Console.ReadKey();
        }
    }
    public class StatisticCalculator
    {
        List<double> data;

        public double Min       { get; private set; }
        public double Max       { get; private set; }
        public double Average   { get; private set; }
        public double Deviation { get; private set; }

        public StatisticCalculator()
        {
            Min = 0.0;
            Max = 0.0;
            Average = 0.0;
            Deviation = 0.0;

            data = new List<double>();
        }

        public void AddValue(double value)
        {
            data.Add(value);
        }

        public void Calculate()
        {
            double sum = 0.0;
            Min = data[0];
            Max = data[0];

            foreach (double value in data)
            {
                if (Min > value)
                    Min = value;

                if (Max < value)
                    Max = value;

                sum += value;
            }

            Average = sum / data.Count;
            sum = 0.0;

            foreach (double value in data)
            {

                sum += Math.Pow(Average - value, 2);
            }

            Deviation = Math.Sqrt(sum / data.Count);
        }
    }

    public class StatisticAnalyzer
    {
        StatisticCalculator statisticCalculator;
        IInputOutput        inputOutput;

        public StatisticAnalyzer(StatisticCalculator sc, IInputOutput io)
        {
            statisticCalculator = sc;
            inputOutput = io;
        }

        public void Run()
        {
            inputOutput.WriteString("Please enter how many number you wish to insert: ");

            int howMany = inputOutput.ReadNumber();

            for (int i = 1; i <= howMany; i++)
            {
                inputOutput.WriteString($"Value[{i}]: ");

                statisticCalculator.AddValue(inputOutput.ReadValue());
            }

            statisticCalculator.Calculate();

            inputOutput.WriteString($"Min:      {statisticCalculator.Min}");
            inputOutput.WriteString($"Max:      {statisticCalculator.Max}");
            inputOutput.WriteString($"Average:  {statisticCalculator.Average}");
            inputOutput.WriteString($"Deviatio: {statisticCalculator.Deviation}");
        }

    } 


    public interface IInputOutput
    {
        int ReadNumber();
        double ReadValue();
        void WriteString(string msg);
    }

    public class ConsoleIO : IInputOutput
    {
        public ConsoleIO ()
        {
        }

        public int ReadNumber()
        {
            int number = 0;

            do
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
                {
                    WriteString("The entered value is invalid. Please try again...");
                }
            }
            while (number < 1);

            return number;
        }

        public double ReadValue()
        {
            double value = 0.0;

            if (!double.TryParse(Console.ReadLine(), out value))
            {
                WriteString("The entered value is invalid. Please try again...");
            }

            return value;
        }

        public void WriteString(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class FileIO : IInputOutput
    {
        FileIO(string input, string output)
        {
        }

        public int ReadNumber()
        {
            int number = 0;



            return number;
        }

        public double ReadValue()
        {
            double value = 0.0;

            return value;
        }

        public void WriteString(string msg)
        {

        }
    }
}
