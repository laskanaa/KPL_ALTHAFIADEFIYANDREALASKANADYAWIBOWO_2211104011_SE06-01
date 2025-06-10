private bool IsValidPassword(string password, string username)
{
   return password.Length >= 8 &&
       password.Length <= 20 &&
       Regex.IsMatch(password, @"[!@#$%^&*]") &&
       !password.Contains(username);
}