namespace DesignPatterns.Core.Behavioral.Mediator.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Mediator Pattern - Ejemplo Básico: Chat Room ===\n");

        var chatRoom = new ChatRoom();

        var user1 = new ChatUser("Alice");
        var user2 = new ChatUser("Bob");
        var user3 = new ChatUser("Charlie");

        chatRoom.RegisterUser(user1);
        chatRoom.RegisterUser(user2);
        chatRoom.RegisterUser(user3);

        Console.WriteLine("\n--- Enviando mensajes ---");
        user1.Send("¡Hola a todos!");
        user2.Send("¿Cómo están?");
        user3.Send("Muy bien, gracias");

        Console.WriteLine("\n--- Envío privado mediante mediador ---");
        chatRoom.SendMessage("Mensaje privado", user1);

        Console.WriteLine("\n Mediator centraliza comunicación entre usuarios");
    }
}