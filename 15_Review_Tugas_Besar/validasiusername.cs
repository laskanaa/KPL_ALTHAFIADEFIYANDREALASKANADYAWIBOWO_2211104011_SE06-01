private bool IsValidUsername(string username)
{
    return username.Length >= 4 && username.Length <= 20 && Regex.IsMatch(username, @"^[a-zA-Z]+$");
}