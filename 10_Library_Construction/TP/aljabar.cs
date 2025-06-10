using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAljabar
{
    public class Aljabar
    {
        public static double[] AkarPersamaanKuadrat(double[] persamaan)
        {
            double a = persamaan[0];
            double b = persamaan[1];
            double c = persamaan[2];

            double diskriminan = b * b - 4 * a * c;

            if (diskriminan < 0)
            {
                throw new Exception("Persamaan tidak memiliki akar real");
            }

            double akar1 = (-b + Math.Sqrt(diskriminan)) / (2 * a);
            double akar2 = (-b - Math.Sqrt(diskriminan)) / (2 * a);

            return new double[] { akar1, akar2 };
        }

        public static double[] HasilKuadrat(double[] persamaan)
        {
            double a = persamaan[0];
            double b = persamaan[1];

            double a2 = a * a;
            double _2ab = 2 * a * b;
            double b2 = b * b;

            return new double[] { a2, _2ab, b2 };
        }
    }
}