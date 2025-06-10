public int CariNilaiPangkat(int a, int b)
{
    if (b == 0) return 1;
    if (b < 0) return -1;
    if (b > 10 || a > 100) return -2;

    try
    {
        checked
        {
            int hasil = 1;
            for (int i = 0; i < b; i++)
            {
                hasil *= a;
            }
            return hasil;
        }
    }
    catch (OverflowException)
    {
        return -3;
    }
}