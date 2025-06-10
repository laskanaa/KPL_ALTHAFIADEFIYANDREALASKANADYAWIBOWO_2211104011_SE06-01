using LibraryAljabar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp10_aljabar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] persamaan1 = { 1, -3, -10 };
            double[] akar = Aljabar.AkarPersamaanKuadrat(persamaan1);
            Console.WriteLine("Akar persamaan x² - 3x - 10 = 0 adalah:");
            Console.WriteLine($"x1 = {akar[0]}, x2 = {akar[1]}");
            Console.WriteLine();

            double[] persamaan2 = { 2, -3 };
            double[] hasilKuadrat = Aljabar.HasilKuadrat(persamaan2);
            Console.WriteLine("Hasil kuadrat dari (2x - 3) adalah:");
            Console.WriteLine($"{hasilKuadrat[0]}x² + {hasilKuadrat[1]}x + {hasilKuadrat[2]}");
        }
    }
}
