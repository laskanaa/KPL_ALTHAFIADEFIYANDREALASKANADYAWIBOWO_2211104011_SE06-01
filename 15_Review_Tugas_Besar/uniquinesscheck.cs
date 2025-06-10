if (users.Any(u => u.Username == username))
{
    Console.WriteLine("Username sudah terdaftar.");
    return;
}