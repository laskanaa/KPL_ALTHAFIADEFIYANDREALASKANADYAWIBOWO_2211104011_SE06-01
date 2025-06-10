using System;
using MatematikaLibraries;

class Program
{
    static void Main()
    {
        Console.WriteLine("FPB(60, 45): " + RumusMatematika.FPB(60, 45));
        Console.WriteLine("KPK(12, 8): " + RumusMatematika.KPK(12, 8));
        Console.WriteLine("Turunan({1, 4, -12, 9}): " + RumusMatematika.Turunan(new int[] { 1, 4, -12, 9 }));
        Console.WriteLine("Integral({4, 6, -12, 9}): " + RumusMatematika.Integral(new int[] { 4, 6, -12, 9 }));
    }
}