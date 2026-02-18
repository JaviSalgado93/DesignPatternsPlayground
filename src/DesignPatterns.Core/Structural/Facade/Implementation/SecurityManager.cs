namespace DesignPatterns.Core.Structural.Facade.Implementation;

/// <summary>
/// Subsistema 3 - Seguridad
/// </summary>
public class SecurityManager
{
    private string _currentUser = "";
    private List<string> _authorizedUsers = new();

    public void Authenticate(string username, string password)
    {
        if (username == "admin" && password == "1234")
        {
            _currentUser = username;
            Console.WriteLine($"[Security] Usuario autenticado: {username}");
        }
        else
        {
            Console.WriteLine("[Security] Autenticación fallida");
        }
    }

    public void AuthorizeUser(string username, string permission)
    {
        _authorizedUsers.Add($"{username}:{permission}");
        Console.WriteLine($"[Security] Permiso otorgado: {username} -> {permission}");
    }

    public bool IsAuthorized(string username, string permission)
    {
        return _authorizedUsers.Contains($"{username}:{permission}");
    }

    public string GetCurrentUser() => _currentUser;

    public void Logout()
    {
        Console.WriteLine($"[Security] Usuario desconectado: {_currentUser}");
        _currentUser = "";
    }
}