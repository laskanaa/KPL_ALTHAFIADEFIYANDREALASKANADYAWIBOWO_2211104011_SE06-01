class Penjumlahan
{
    public T JumlahTigaAngka<T>(T a, T b, T c)
    {
        dynamic tempA = a;
        dynamic tempB = b;
        dynamic tempC = c;
        return (T)(tempA + tempB + tempC);
    }
}



class Program
{
    static void Main()
    {
        // Tugas No. 4 - Implementasi Generic Method
        Penjumlahan penjumlahan = new Penjumlahan();
        int angka1 = 11;
        int angka2 = 12;
        int angka3 = 13;
        int hasil = penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);
        Console.WriteLine("Hasil Penjumlahan: " + hasil);

    }
}