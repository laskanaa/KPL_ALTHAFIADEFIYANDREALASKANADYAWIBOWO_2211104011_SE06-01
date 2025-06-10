using System;
using System.Collections.Generic;

public class PusatDataSingleton
{
    // Property Singleton
    private static PusatDataSingleton? _instance;

    // Atribut untuk menyimpan data
    private List<string> DataTersimpan;

    // Konstruktor private (agar tidak bisa dibuat objek dari luar)
    private PusatDataSingleton()
    {
        DataTersimpan = new List<string>();
    }

    // Method untuk mengakses instance Singleton
    public static PusatDataSingleton GetDataSingleton()
    {
        if (_instance == null)
        {
            _instance = new PusatDataSingleton();
        }
        return _instance;
    }

    // Menambahkan data ke list
    public void AddSebuahData(string input)
    {
        DataTersimpan.Add(input);
    }

    // Menghapus data berdasarkan index
    public void HapusSebuahData(int index)
    {
        if (index >= 0 && index < DataTersimpan.Count)
        {
            DataTersimpan.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Index tidak valid!");
        }
    }

    // Mengembalikan list data
    public List<string> GetSemuaData()
    {
        return DataTersimpan;
    }

    // Menampilkan semua data
    public void PrintSemuaData()
    {
        if (DataTersimpan.Count == 0)
        {
            Console.WriteLine("Tidak ada data tersimpan.");
            return;
        }

        Console.WriteLine("Isi Data yang Tersimpan:");
        for (int i = 0; i < DataTersimpan.Count; i++)
        {
            Console.WriteLine($"{i}. {DataTersimpan[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var data1 = PusatDataSingleton.GetDataSingleton();
        var data2 = PusatDataSingleton.GetDataSingleton();

        data1.AddSebuahData("Althafia Defiyandrea");
        data1.AddSebuahData("Maria Nathasya");
        data1.AddSebuahData("Lintang Suminar");

        Console.WriteLine("\nPrint dari data-2:");
        data2.PrintSemuaData();

        Console.WriteLine("\nMenghapus Sesuatu Entitas Hitam");
        data2.HapusSebuahData(data2.GetSemuaData().IndexOf("Sesuatu Entitas Hitam"));

        Console.WriteLine("\nPrint dari data-1 setelah penghapusan:");
        data1.PrintSemuaData();

        Console.WriteLine($"\nJumlah data di data-1: {data1.GetSemuaData().Count}");
        Console.WriteLine($"Jumlah data di data-2: {data2.GetSemuaData().Count}");
    }
}