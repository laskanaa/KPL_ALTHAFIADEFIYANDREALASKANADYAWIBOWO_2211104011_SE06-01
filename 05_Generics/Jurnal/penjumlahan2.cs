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

class SimpleDataBase<T>
{
    private List<T> storedData;
    private List<DateTime> inputDates;

    public SimpleDataBase()
    {
        storedData = new List<T>();
        inputDates = new List<DateTime>();
    }

    public void AddNewData(T data)
    {
        storedData.Add(data);
        inputDates.Add(DateTime.UtcNow);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
        }
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

        // Implementasi database generik
        SimpleDataBase<int> database = new SimpleDataBase<int>();
        database.AddNewData(11);
        database.AddNewData(12);
        database.AddNewData(13);
        database.PrintAllData();
    }
}