private void button1_Click(object sender, EventArgs e)
{
    int a, b;
    if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
    {
        int hasil = CariNilaiPangkat(a, b);
        label1.Text = $"Hasil: {hasil}";
    }
    else
    {
        label1.Text = "Input tidak valid!";
    }
}