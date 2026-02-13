namespace DesignPatterns.Core.Creational.Builder.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Builder Pattern - Ejemplo Avanzado: HTTP Request ===\n");

        // Construir un GET request
        var getRequest = new HttpRequestBuilder()
            .WithUrl("https://api.example.com/users")
            .WithMethod("GET")
            .AddQueryParameter("page", "1")
            .AddQueryParameter("limit", "10")
            .AddHeader("Authorization", "Bearer token123")
            .AddHeader("Accept", "application/json")
            .WithTimeout(10000)
            .Build();

        Console.WriteLine("GET Request:");
        getRequest.Display();

        // Construir un POST request
        var postRequest = new HttpRequestBuilder()
            .WithUrl("https://api.example.com/users")
            .WithMethod("POST")
            .AddHeader("Authorization", "Bearer token123")
            .AddHeader("Content-Type", "application/json")
            .WithBody(@"{""name"":""Juan"",""email"":""juan@example.com""}")
            .WithTimeout(5000)
            .FollowRedirects(false)
            .Build();

        Console.WriteLine("\nPOST Request:");
        postRequest.Display();

        Console.WriteLine("\n✅ Builder gestiona requests HTTP complejos de forma elegante");
    }
}