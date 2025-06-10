public void Register()
{
    Console.Write("Masukkan username: ");
    string username = Console.ReadLine();

    if (!IsValidUsername(username))
    {
        Console.WriteLine("Username tidak valid. Hanya huruf dan panjang 4-20 karakter.");
        return;
    }

    Console.Write("Masukkan password: ");
    string password = Program.ReadPassword();

    if (!IsValidPassword(password, username))
    {
        Console.WriteLine("Password tidak valid. Panjang 8-20, harus ada simbol khusus (!@#$%^&*), dan tidak mengandung username.");
        return;
    }

    if (users.Any(u => u.Username == username))
    {
        Console.WriteLine("Username sudah terdaftar.");
        return;
    }

    users.Add(new User
    {
        Username = username,
        PasswordHash = HashPassword(password)
    });

    SaveUsers();
    Console.WriteLine("Registrasi berhasil!");
}