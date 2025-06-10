private readonly string filePath = "users.json";
private List<User> users;

public UserService()
{
    users = LoadUsers();
}

private List<User> LoadUsers()
{
    if (!File.Exists(filePath))
        return new List<User>();

    var json = File.ReadAllText(filePath);
    return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
}