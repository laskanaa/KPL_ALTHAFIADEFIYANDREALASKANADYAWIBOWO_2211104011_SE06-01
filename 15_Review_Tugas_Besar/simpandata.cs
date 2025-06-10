private void SaveUsers()
{
    var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, json);
}