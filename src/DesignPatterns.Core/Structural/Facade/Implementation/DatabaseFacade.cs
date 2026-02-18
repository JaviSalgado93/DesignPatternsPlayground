namespace DesignPatterns.Core.Structural.Facade.Implementation;

/// <summary>
/// Facade - Interfaz simplificada para el subsistema complejo
/// </summary>
public class DatabaseFacade
{
    private DatabaseConnection _database;
    private Logger _logger;
    private SecurityManager _security;
    private QueryExecutor _queryExecutor;

    public DatabaseFacade()
    {
        _database = new DatabaseConnection();
        _logger = new Logger();
        _security = new SecurityManager();
        _queryExecutor = new QueryExecutor(_database);
    }

    /// <summary>
    /// Operación simplificada: Conectar y autenticar
    /// </summary>
    public bool ConnectAndAuthenticate(string connectionString, string username, string password)
    {
        Console.WriteLine("=== Conectando a base de datos ===");
        _database.Connect(connectionString);
        _logger.Log($"Intento de conexión con usuario: {username}");

        _security.Authenticate(username, password);

        if (string.IsNullOrEmpty(_security.GetCurrentUser()))
        {
            _logger.Log("Falló la autenticación");
            return false;
        }

        _logger.Log($"Conexión establecida para: {username}");
        return true;
    }

    /// <summary>
    /// Operación simplificada: Ejecutar consulta con permisos
    /// </summary>
    public bool ExecuteQueryWithPermission(string query, string permission)
    {
        var currentUser = _security.GetCurrentUser();

        if (!_security.IsAuthorized(currentUser, permission))
        {
            _logger.Log($"Acceso denegado para {currentUser} - Permiso requerido: {permission}");
            return false;
        }

        _logger.Log($"Ejecutando consulta: {query}");
        _queryExecutor.ExecuteQuery(query);
        return true;
    }

    /// <summary>
    /// Operación simplificada: Obtener datos
    /// </summary>
    public List<string> GetData()
    {
        _logger.Log("Obteniendo datos");
        return _queryExecutor.FetchResults();
    }

    /// <summary>
    /// Operación simplificada: Desconectar
    /// </summary>
    public void Disconnect()
    {
        _logger.Log("Desconectando");
        _security.Logout();
        _database.Disconnect();
        _logger.SaveToFile("database.log");
    }

    /// <summary>
    /// Operación simplificada: Autorizar usuario
    /// </summary>
    public void AuthorizeUser(string username, string permission)
    {
        _security.AuthorizeUser(username, permission);
        _logger.Log($"Usuario autorizado: {username} -> {permission}");
    }
}