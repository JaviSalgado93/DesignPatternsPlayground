namespace DesignPatterns.Core.Creational.Builder.Examples._02_Advanced;

public class HttpRequest
{
    public string Method { get; set; } = "GET";
    public string Url { get; set; }
    public Dictionary<string, string> Headers { get; set; } = new();
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public string Body { get; set; }
    public int TimeoutMs { get; set; } = 5000;
    public bool FollowRedirects { get; set; } = true;

    public void Display()
    {
        Console.WriteLine("\n=== HTTP Request ===");
        Console.WriteLine($"Método: {Method}");
        Console.WriteLine($"URL: {Url}");

        if (QueryParameters.Count > 0)
        {
            Console.WriteLine("Parámetros:");
            foreach (var param in QueryParameters)
            {
                Console.WriteLine($"  {param.Key} = {param.Value}");
            }
        }

        if (Headers.Count > 0)
        {
            Console.WriteLine("Headers:");
            foreach (var header in Headers)
            {
                Console.WriteLine($"  {header.Key}: {header.Value}");
            }
        }

        if (!string.IsNullOrEmpty(Body))
        {
            Console.WriteLine($"Body: {Body}");
        }

        Console.WriteLine($"Timeout: {TimeoutMs}ms");
        Console.WriteLine($"Seguir redirecciones: {FollowRedirects}");
    }
}

/// <summary>
/// Builder para construir HTTP requests complejos
/// </summary>
public class HttpRequestBuilder
{
    private HttpRequest _request = new();

    public HttpRequestBuilder WithUrl(string url)
    {
        _request.Url = url;
        return this;
    }

    public HttpRequestBuilder WithMethod(string method)
    {
        _request.Method = method;
        return this;
    }

    public HttpRequestBuilder AddHeader(string key, string value)
    {
        _request.Headers[key] = value;
        return this;
    }

    public HttpRequestBuilder AddQueryParameter(string key, string value)
    {
        _request.QueryParameters[key] = value;
        return this;
    }

    public HttpRequestBuilder WithBody(string body)
    {
        _request.Body = body;
        return this;
    }

    public HttpRequestBuilder WithTimeout(int ms)
    {
        _request.TimeoutMs = ms;
        return this;
    }

    public HttpRequestBuilder FollowRedirects(bool follow)
    {
        _request.FollowRedirects = follow;
        return this;
    }

    public HttpRequest Build()
    {
        if (string.IsNullOrEmpty(_request.Url))
            throw new InvalidOperationException("URL es requerida");

        return _request;
    }
}