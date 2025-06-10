private void button1_Click(object sender, EventArgs e)
{
    if (int.TryParse(txtinput.Text, out int angka))
    {
        lblhasil.Text = "Hasil: " + CariTandaBilangan(angka);
    }
    else
    {
        lblhasil.Text = "Input tidak valid!";
    }
}