#1
using System;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine(); // Membaca input nama dari pengguna

        Console.WriteLine($"Selamat datang, {nama}!"); // Menampilkan pesan selamat datang
    }
}


#2

using System;

class Program
{
    static void Main()
    {
        int[] array = new int[50]; // Membuat array dengan 50 elemen

        // Mengisi array dengan nilai sesuai indeksnya
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        // Menampilkan output sesuai aturan
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0 && i % 3 == 0)
            {
                Console.WriteLine($"{array[i]} #$#$");
            }
            else if (i % 2 == 0)
            {
                Console.WriteLine($"{array[i]} ##");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine($"{array[i]} $$");
            }
            else
            {
                Console.WriteLine($"{array[i]}");
            }
        }
    }
}

#3

using System;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan angka (1-10000): ");
        string nilaiString = Console.ReadLine(); // Menerima input sebagai string
        int nilaiInt = Convert.ToInt32(nilaiString); // Mengonversi string ke integer

        if (IsPrima(nilaiInt))
        {
            Console.WriteLine($"Angka {nilaiInt} merupakan bilangan prima");
        }
        else
        {
            Console.WriteLine($"Angka {nilaiInt} bukan merupakan bilangan prima");
        }
    }

    static bool IsPrima(int angka)
    {
        if (angka < 2)
            return false;
        for (int i = 2; i * i <= angka; i++) // Mengecek dari 2 hingga akar angka
        {
            if (angka % i == 0)
                return false; // Jika habis dibagi i, bukan bilangan prima
        }
        return true; // Jika tidak ada pembagi selain 1 dan dirinya sendiri
    }
}
