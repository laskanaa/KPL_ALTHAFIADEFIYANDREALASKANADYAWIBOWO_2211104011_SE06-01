using System;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan satu huruf: ");
        char huruf = Char.ToUpper(Console.ReadKey().KeyChar); // Membaca input dan mengubah ke huruf besar
        Console.WriteLine(); // Pindah baris setelah input

        if (huruf == 'A' || huruf == 'I' || huruf == 'U' || huruf == 'E' || huruf == 'O')
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf vokal");
        }
        else
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf konsonan");
        }
    }
}

using System;

class Program
{
    static void Main()
    {
        // Membuat array dengan 5 bilangan genap dari angka 2
        int[] angkaGenap = { 2, 4, 6, 8, 10 };

        // Iterasi dan cetak output
        for (int i = 0; i < angkaGenap.Length; i++)
        {
            Console.WriteLine($"Angka genap {i + 1} : {angkaGenap[i]}");
        }
    }
}

