using System;

class Program
{
    static void Main()
    {
        // Memanggil metode generic SapaUser
        HaloGeneric.SapaUser("Althafia");

        // Menggunakan kelas DataGeneric
        DataGeneric<string> dataGeneric = new DataGeneric<string>("NIM : 2211104011");
        dataGeneric.PrintData();
    }
}
