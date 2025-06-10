using System;
using System.Collections.Generic;

namespace TpModul14_2211104011
{
    public class Calculator
    {
        public T SumThreeNumbers<T>(T a, T b, T c)
        {
            dynamic x = a, y = b, z = c;
            return (T)(x + y + z);
        }
    }

    public class SimpleDatabase<T>
    {
        private readonly List<T> _storedData;
        private readonly List<DateTime> _inputDates;

        public SimpleDatabase()
        {
            _storedData = new List<T>();
            _inputDates = new List<DateTime>();
        }

        public void AddNewData(T data)
        {
            _storedData.Add(data);
            _inputDates.Add(DateTime.UtcNow);
        }

        public void PrintAllData()
        {
            for (int i = 0; i < _storedData.Count; i++)
            {
                Console.WriteLine($"Data {i + 1}: {_storedData[i]}, saved at UTC: {_inputDates[i]}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Implementasi Generic Method
            var calculator = new Calculator();
            int a = 22, b = 40, c = 27;
            int result = calculator.SumThreeNumbers(a, b, c);
            Console.WriteLine($"Sum Result: {result}");

            // Implementasi Generic Class
            var database = new SimpleDatabase<int>();
            database.AddNewData(a);
            database.AddNewData(b);
            database.AddNewData(c);
            database.PrintAllData();
        }
    }
}