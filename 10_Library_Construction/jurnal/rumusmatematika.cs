namespace MatematikaLibraries
{
    public class RumusMatematika
    {
        public static int FPB(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static int KPK(int a, int b)
        {
            return Math.Abs(a * b) / FPB(a, b);
        }

        public static string Turunan(int[] koefisien)
        {
            List<string> hasil = new();
            int pangkat = koefisien.Length - 1;

            for (int i = 0; i < koefisien.Length - 1; i++)
            {
                int koef = koefisien[i] * pangkat;

                if (koef == 0)
                {
                    pangkat--;
                    continue;
                }

                string bagian = "";

                // Tanda positif/negatif
                if (koef > 0 && hasil.Count > 0)
                    bagian += "+ ";
                else if (koef < 0)
                    bagian += "- ";

                int nilai = Math.Abs(koef);

                // Format bagian turunan sesuai pangkat
                if (pangkat - 1 > 1)
                    bagian += $"{nilai}x{pangkat - 1}";
                else if (pangkat - 1 == 1)
                    bagian += $"{nilai}x";
                else
                    bagian += $"{nilai}";

                hasil.Add(bagian);
                pangkat--;
            }

            return string.Join(" ", hasil);
        }


        public static string Integral(int[] koefisien)
        {
            List<string> hasil = new();
            int pangkat = koefisien.Length;
            for (int i = 0; i < koefisien.Length; i++)
            {
                double koef = (double)koefisien[i] / (pangkat - i);
                string bagian = $"{(koef > 0 && i > 0 ? "+ " : (koef < 0 ? "- " : ""))}{Math.Abs(koef)}x";
                if (pangkat - i > 1)
                    bagian += $"{pangkat - i}";
                hasil.Add(bagian);
            }
            hasil.Add("+ C");
            return string.Join(" ", hasil);
        }
    }
}